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
    /// Логика взаимодействия для DeletePage.xaml
    /// </summary>
    public partial class DeletePage : Page
    {
        public DeletePage()
        {
            InitializeComponent();
            context = new PhoneContext();
            service = new DeleteService(context);
            personalGrid.ItemsSource = context.PersPhone.ToList();
            corporativeGrid.ItemsSource = context.CorpPhones.ToList();
        }

        PhoneContext context;
        DeleteService service;

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

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (personalGrid.Visibility == Visibility.Visible)
            {
                personalGrid = service.DeletePersonal(personalGrid);
            }
            else
            {
                corporativeGrid = service.DeleteCorporative(corporativeGrid);
            }
        }
    }
    
}
