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

namespace Telephone
{
    /// <summary>
    /// Логика взаимодействия для AutentificationPage.xaml
    /// </summary>
    public partial class AutentificationPage : Page
    {
        public AutentificationPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {       
            if (LoginValidation() & PasswordValidation())
            {
                if ((loginTextBox.Text == "admin") && (passwordBox.Password == "admin"))
                {
                    NavigationService.Navigate(new AdminPage());
                }
                else
                {
                    errorLabel.Content = "Логин или пароль введены неверно!\nПопробуйте ещё раз!";
                    errorLabel.Width = loginTextBox.Width;
                    errorLabel.Visibility = Visibility.Visible;
                }    
                               
            }
            
        }

        private bool LoginValidation()
        {
            if (loginTextBox.Text.Length == 0)
            {
                emptyLoginLabel.Visibility = Visibility.Visible;
                return false;
            }
            
            if ((loginTextBox.Text.Length < 3) || (loginTextBox.Text.Length > 20))
            {
                errorLabel.Content = "Логин должен содержать от 3 до 20 символов";
                errorLabel.Width = loginTextBox.Width;
                errorLabel.Visibility = Visibility.Visible;
                return false;
            }
            
            return true;
        }

        private bool PasswordValidation()
        {
            if (passwordBox.Password.Length == 0)
            {
                emptyPasswordLabel.Visibility = Visibility.Visible;
                return false;
            }

            if ((passwordBox.Password.Length < 3) || (passwordBox.Password.Length > 20))
            {
                errorLabel.Content = "Пароль должен содержать от 3 до 20 символов";
                errorLabel.Width = loginTextBox.Width;
                errorLabel.Visibility = Visibility.Visible;
                return false;
            }

            return true;             
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StartPage());
        }

        private void loginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            emptyLoginLabel.Visibility = Visibility.Hidden;
            errorLabel.Visibility = Visibility.Collapsed;
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            emptyPasswordLabel.Visibility = Visibility.Hidden;
            errorLabel.Visibility = Visibility.Collapsed;
        }
    }
}
