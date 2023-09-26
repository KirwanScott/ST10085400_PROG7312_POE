using ST10085400_PROG7312_POE.Core;
using ST10085400_PROG7312_POE.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ST10085400_PROG7312_POE.MVVM.View_Model
{
    public class LoginViewModel: ObservableObject
    {
        private string username;
        private string password;
        //private string regUsername;
        //private string regPassword;
        private string confirmPassword;
        private string errorMessage;
        private string regErrorMessage;

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public string RegUsername
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        public string RegPassword
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                OnPropertyChanged();
            }
        }

        public string RegErrorMessage
        {
            get { return regErrorMessage; }
            set
            {
                regErrorMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        private DBManager dbManager;

        public ICommand ExitApplicationCommand { get; set; }
        public ICommand Guest {  get; set; }

        public LoginViewModel()
        {
            dbManager = new DBManager();

            LoginCommand = new RelayCommand(Login);
            RegisterCommand = new RelayCommand(Register);
            ExitApplicationCommand = new RelayCommand(ExitApplication);
            Guest = new RelayCommand(LoginGuest);
        }

        private void Login(object parameter)
        {
            // Check if the username and password match a record in the database
            string inputUsername = Username;
            string inputPassword = Password;

           
            bool isLoginSuccessful = dbManager.ValidateUser(inputUsername, inputPassword);

            

            if (isLoginSuccessful)
            {
                // Login successful, navigate to the MainWindow
                ErrorMessage = string.Empty; // Clear any previous error messages

                // Create and show the MainWindow
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                //if(Application.Current.MainWindow != null)
                //{
                //    Application.Current.MainWindow.Close();
                //}

                // Close the current login window
                Application.Current.MainWindow.Close();
            }
            else
            {
                // Login failed, set an error message.
                ErrorMessage = "Invalid username or password. Please try again.";
            }
        }

        private void Register(object parameter)
{
    try
    {
        // Validate user input
        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
        {
            RegErrorMessage = "Username and password are required.";
            return;
        }

        // Check if the username already exists in the database
        bool usernameExists = dbManager.UsernameExists(Username);

        if (usernameExists)
        {
            RegErrorMessage = "Username already exists. Please choose a different one.";
            return;
        }

        // If all validations pass, insert the user into the database
        dbManager.AddUser(Username, Password);

                // Clear registration-related fields and messages
                Username = string.Empty;
                Password = string.Empty;
                RegErrorMessage = string.Empty;

        // Optionally, you can display a success message to the user
        ErrorMessage = "Registration successful! You can now log in.";
    }
    catch (Exception ex)
    {
        // Log the exception details for debugging
        Console.WriteLine("Error registering user: " + ex.Message);
        RegErrorMessage = "Error registering user. Please try again later.";
    }
}

        private void ExitApplication(object parameter)
        {
            // This command will shut down the entire application
            Application.Current.Shutdown();
        }

        private void LoginGuest(object parameter)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            //if(Application.Current.MainWindow != null)
            //{
            //    Application.Current.MainWindow.Close();
            //}

            // Close the current login window
            Application.Current.MainWindow.Close();
        }


    }
}
