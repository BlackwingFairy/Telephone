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
using Telephone.Models;
using Telephone.Services;

namespace Telephone
{
    /// <summary>
    /// Логика взаимодействия для RedactionPage.xaml
    /// </summary>
    public partial class RedactionPage : Page
    {
        public RedactionPage()
        {
            InitializeComponent();
            context = new PhoneContext();
            service = new RedactionService(context);
            personalGrid.ItemsSource = context.PersPhone.ToList();
            corporativeGrid.ItemsSource = context.CorpPhones.ToList();
        }

        PhoneContext context;
        RedactionService service;

        private void personalButton_Click(object sender, RoutedEventArgs e)
        {
            personalGrid.Visibility = Visibility.Visible;
            corporativeGrid.Visibility = Visibility.Collapsed;
        }

        private void corpButton_Click(object sender, RoutedEventArgs e)
        {
            corporativeGrid.Visibility = Visibility.Visible;
            personalGrid.Visibility = Visibility.Collapsed;
        }

        private void returnLink_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void redactionButton_Click(object sender, RoutedEventArgs e)
        {
            RedactionData data = service.GetPhone(personalGrid, corporativeGrid);
            NavigationService.Navigate(new ViewRedactionPage() { Phone = data.Phone, Table = data.Table });
        }

        
    }
}
