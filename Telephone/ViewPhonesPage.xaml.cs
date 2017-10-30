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
    /// Логика взаимодействия для ViewPhonesPage.xaml
    /// </summary>
    public partial class ViewPhonesPage : Page
    {
        public ViewPhonesPage()
        {
            InitializeComponent();
            PhoneContext db = new PhoneContext();
            personalGrid.ItemsSource = db.PersPhone.ToList<PersonalTelephone>();
            corporativeGrid.ItemsSource = db.CorpPhones.ToList<CorporativeTelephone>();
        }

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
    }
}
