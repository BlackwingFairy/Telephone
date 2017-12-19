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
using Telephone.Services;

namespace Telephone
{
    /// <summary>
    /// Логика взаимодействия для AutentificationPage.xaml
    /// </summary>
    public partial class AutentificationPage : Page
    {
        ValidationServise service;
        public AutentificationPage()
        {
            InitializeComponent();
            service = new ValidationServise();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            bool loginValid = service.LoginValidation(loginTextBox.Text,errorLabel, emptyLoginLabel, loginTextBox.Width);
            bool passwordValid = service.PasswordValidation(passwordBox.Password,errorLabel, emptyPasswordLabel, loginTextBox.Width);
            bool canEnter = service.СanEnter(loginTextBox.Text, passwordBox.Password, errorLabel, loginTextBox.Width);
            if (loginValid & passwordValid & canEnter)
            {
                NavigationService.Navigate(new AdminPage());
            }            
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
