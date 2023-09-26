using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ST10085400_PROG7312_POE.Core;
using System.Linq;
using System.Windows;
using ST10085400_PROG7312_POE.MVVM.Model;

namespace ST10085400_PROG7312_POE.MVVM.View_Model
{
    public class ReplacingBooksViewModel : ObservableObject
    {
        public LinkedList generatedCallNumbers = new LinkedList();

        public ObservableCollection<double> userOrderedCallNumbers;
        public ObservableCollection<double> bottomRowNumbers;
        public int currentPoints;
        public int incorrectPoints = -5; // Set the incorrect point value

        // Maintain a HashSet to track numbers in the bottom row
        public HashSet<double> bottomRowNumberSet = new HashSet<double>();

        public ObservableCollection<double> UserOrderedCallNumbers
        {
            get { return userOrderedCallNumbers; }
            set
            {
                userOrderedCallNumbers = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<double> BottomRowNumbers
        {
            get { return bottomRowNumbers; }
            set
            {
                bottomRowNumbers = value;
                OnPropertyChanged();
            }
        }

        public int CurrentPoints
        {
            get { return currentPoints; }
            set
            {
                currentPoints = value;
                OnPropertyChanged();

                // Check if the current points are greater than the high score points
                if (currentPoints > HighScoreManager.Instance.HighScore)
                {
                    HighScoreManager.Instance.HighScore = currentPoints; // Update the high score
                    OnPropertyChanged(nameof(HighScorePoints)); // Notify of the high score change
                }
            }
        }

        public int HighScorePoints
        {
            get { return HighScoreManager.Instance.HighScore; }
            set
            {
                HighScoreManager.Instance.HighScore = value;
                OnPropertyChanged();
            }
        }

        public ICommand GenerateCallNumbersCommand { get; set; }
        public ICommand SortOrderCommand { get; set; }
        public ICommand CheckOrderCommand { get; set; }
        public ICommand AddToBottomRowCommand { get; set; }
        public ICommand UndoCommand { get; set; }
        public ICommand HelpCommand { get; set; }

        public ReplacingBooksViewModel()
        {
            UserOrderedCallNumbers = new ObservableCollection<double>();
            BottomRowNumbers = new ObservableCollection<double>();
            CurrentPoints = 0;

            GenerateCallNumbersCommand = new RelayCommand(GenerateCallNumbers);
            SortOrderCommand = new RelayCommand(SortOrder);
            CheckOrderCommand = new RelayCommand(CheckOrder);
            AddToBottomRowCommand = new RelayCommand(AddToBottomRow);
            BottomRowNumbers = new ObservableCollection<double>();
            UndoCommand = new RelayCommand(Undo);
            HelpCommand = new RelayCommand(Help);
        }

        public void GenerateCallNumbers(object parameter)
        {
            // Clear the previous data
            generatedCallNumbers.Clear();
            UserOrderedCallNumbers.Clear();
            BottomRowNumbers.Clear();
            bottomRowNumberSet.Clear(); // Clear the HashSet

            // Generate 10 different random call numbers with decimals within a specified range
            Random random = new Random();
            while (generatedCallNumbers.Count < 10)
            {
                double randomNumber = random.NextDouble() * (900.0 - 0.0) + 0.0; // Generates a random double between 0.0 and 900.0

                if (!generatedCallNumbers.Contains(randomNumber))
                {
                    generatedCallNumbers.AddToEnd(randomNumber);
                }
            }

            // Display the generated call numbers to the user with two decimal places
            foreach (double number in generatedCallNumbers.ToArray())
            {
                UserOrderedCallNumbers.Add(Math.Round(number, 2)); // Round to two decimal places
            }
        }

        public void SortOrder(object parameter)
        {
            // Check if the generated call numbers are in ascending order
            bool isCorrectOrder = IsAscendingOrder(generatedCallNumbers.ToArray());

            if (isCorrectOrder)
            {
                // Sort the generated call numbers in ascending order
                LinkedList sortedNumbers = new LinkedList();
                double[] sortedArray = generatedCallNumbers.ToArray();
                Array.Sort(sortedArray);

                foreach (double number in sortedArray)
                {
                    sortedNumbers.AddToEnd(number);
                }

                generatedCallNumbers = sortedNumbers;

                // Display the sorted numbers in a message box
                string sortedNumbersString = string.Join(", ", sortedArray.Select(n => n.ToString("0.00")));
                MessageBox.Show($"The correct order is:\n{sortedNumbersString}", "Correct Order", MessageBoxButton.OK, MessageBoxImage.Question);
            }
            else
            {
                // Sort the generated call numbers in ascending order
                LinkedList sortedNumbers = new LinkedList();
                double[] sortedArray = generatedCallNumbers.ToArray();
                Array.Sort(sortedArray);

                foreach (double number in sortedArray)
                {
                    sortedNumbers.AddToEnd(number);
                }

                generatedCallNumbers = sortedNumbers;

                // Display the sorted numbers in a message box
                string sortedNumbersString = string.Join(", ", sortedArray.Select(n => n.ToString("0.00")));
                MessageBox.Show($"The correct order is:\n{sortedNumbersString}", "Correct Order", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

        public void CheckOrder(object parameter)
        {
            // Check if the user-ordered list is full
            if (BottomRowNumbers.Count < 10)
            {
                MessageBox.Show("Please complete the bottom row before checking the order.", "Incomplete Bottom Row", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Check if the user's order matches the sorted order
            bool isCorrectOrder = IsAscendingOrder(BottomRowNumbers);

            // You can handle the result here, e.g., display a message to the user
            if (isCorrectOrder)
            {
                // User's order is correct
                // Add points for a correct order
                CurrentPoints += 10;
                GenerateCallNumbers(null);
            }
            else
            {
                // User's order is incorrect
                // Subtract points for an incorrect order
                CurrentPoints += incorrectPoints;
            }
        }

        public void AddToBottomRow(object parameter)
        {
            // Check if the user-ordered list is full
            if (BottomRowNumbers.Count < 10)
            {
                double droppedItem = (double)parameter;

                // Check if the number is already in the bottom row
                if (!bottomRowNumberSet.Contains(droppedItem))
                {
                    BottomRowNumbers.Add(droppedItem);
                    bottomRowNumberSet.Add(droppedItem); // Add it to the HashSet
                }
            }
        }

        public void Undo(object parameter)
        {
            if (BottomRowNumbers.Count > 0)
            {
                // Remove the last number from the bottom row
                double removedItem = BottomRowNumbers[BottomRowNumbers.Count - 1];
                BottomRowNumbers.RemoveAt(BottomRowNumbers.Count - 1);

                // Remove it from the HashSet
                bottomRowNumberSet.Remove(removedItem);
            }
        }

        public void Help(object parameter)
        {
            string help = "Welcome to the Replacing Books Game!!\n\n" +
                "1. Click 'Start' to generate 10 random numbers.\n" +
                "2. Sort the numbers in Ascending order by clicking on one of the 10 random numbers.\n" +
                "3. If you have made a mistake along the way click 'Undo', this will undo your previous mistake.\n" +
                "4. If you are happy with the order your Numbers are in click 'Check Order'.\n" +
                "5. If the order is correct the user will get +10 points, if the order is incorrect the user will get -5 points.\n" +
                "6. To take a sneak peek at the answer click 'Show Answer'.\n" +
                "7. Now Have fun and try and beat your HIGH SCORE!!.\n\n" +
                "Enjoy the Game";
            MessageBox.Show(help, "HELP", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //This method uses insertion sorting
        public bool IsAscendingOrder(IEnumerable<double> list)
        {
            List<double> sortedList = new List<double>(list);

            for (int i = 1; i < sortedList.Count; i++)
            {
                double currentNumber = sortedList[i];
                int j = i - 1;

                while (j >= 0 && sortedList[j] > currentNumber)
                {
                    sortedList[j + 1] = sortedList[j];
                    j--;
                }

                sortedList[j + 1] = currentNumber;
            }

            for (int i = 0; i < sortedList.Count; i++)
            {
                if (list.ElementAt(i) != sortedList[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
