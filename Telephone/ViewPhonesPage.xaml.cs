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
    /// Логика взаимодействия для ViewPhonesPage.xaml
    /// </summary>
    public partial class ViewPhonesPage : Page
    {
        public ViewPhonesPage()
        {
            InitializeComponent();
        }

        private void personalButton_Click(object sender, RoutedEventArgs e)
        {
            frame.Source = new Uri("PersonalPhonesView.xaml", UriKind.RelativeOrAbsolute);
        }

        private void corpButton_Click(object sender, RoutedEventArgs e)
        {
            frame.Source = new Uri("CorporativePhonesView.xaml", UriKind.RelativeOrAbsolute);
        }

        private void returnLink_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
