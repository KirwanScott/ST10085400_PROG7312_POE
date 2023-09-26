using ST10085400_PROG7312_POE.MVVM.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ST10085400_PROG7312_POE.MVVM.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
            PasswordBoxControl.PasswordChanged += PasswordBoxControl_PasswordChanged;
        }

        private void PasswordBoxControl_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Update the Password property in the view model with the entered password
            if (DataContext is View_Model.LoginViewModel viewModel)
            {
                viewModel.Password = PasswordBoxControl.Password;
            }
        }
    }
}
