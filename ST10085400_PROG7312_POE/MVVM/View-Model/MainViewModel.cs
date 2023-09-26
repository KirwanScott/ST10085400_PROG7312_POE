using ST10085400_PROG7312_POE.Core;
using ST10085400_PROG7312_POE.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ST10085400_PROG7312_POE.MVVM.View_Model
{
    public class MainViewModel: ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand ReplaceBooksCommand { get; set; }
        public RelayCommand IdentifyAreasCommand { get; set; }
        public RelayCommand FindCallNumberCommand { get; set; }
        public HomeViewModel HomeVM {  get; set; }
        public ReplacingBooksViewModel ReplacingBooksVM { get; set; }
        public IdentifyingAreasViewModel IdentifyingAreasVM { get; set; }
        public FindCallNumbersViewModel FindCallNumbersVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
            
        }

        public ICommand ExitApplicationCommand { get; set; }

        public MainViewModel() 
        {
            HomeVM = new HomeViewModel();
            ReplacingBooksVM = new ReplacingBooksViewModel();
            IdentifyingAreasVM = new IdentifyingAreasViewModel();
            FindCallNumbersVM = new FindCallNumbersViewModel();
            CurrentView = HomeVM;
            ExitApplicationCommand = new RelayCommand(ExitApplication);

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            ReplaceBooksCommand = new RelayCommand(o =>
            {
                CurrentView = ReplacingBooksVM;
            });

            IdentifyAreasCommand = new RelayCommand(o =>
            {
                CurrentView = IdentifyingAreasVM;
            });

            FindCallNumberCommand = new RelayCommand(o =>
            {
                CurrentView = FindCallNumbersVM;
            });
        }

        private void ExitApplication(object parameter)
        {
            // This command will shut down the entire application
            Application.Current.Shutdown();
        }

    }
}
