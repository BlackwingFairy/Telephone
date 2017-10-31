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
            PhoneContext db = new PhoneContext();
            personalGrid.ItemsSource = db.PersPhone.ToList();
            corporativeGrid.ItemsSource = db.CorpPhones.ToList();
        }

        PhoneContext db = new PhoneContext();

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
            if (personalGrid.Visibility == Visibility.Visible)
            {
                if (personalGrid.SelectedItems.Count > 0)
                {                    
                    PersonalTelephone phone = personalGrid.SelectedItem as PersonalTelephone;
                    NavigationService.Navigate(new ViewRedactionPage() { Phone=phone, T=0 });
                }
                
            }
            if (corporativeGrid.Visibility == Visibility.Visible)
            {
                if (corporativeGrid.SelectedItems.Count > 0)
                {
                    CorporativeTelephone phone = corporativeGrid.SelectedItem as CorporativeTelephone;
                    NavigationService.Navigate(new ViewRedactionPage() { Phone = phone, T = 1 });
                }
                
            }
            
        }
    }
}
