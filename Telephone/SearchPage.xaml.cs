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
    /// Логика взаимодействия для SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        public SearchPage()
        {
            InitializeComponent();
            context = new PhoneContext();
            service = new SearchService(context);
            vService = new ValidationServise();
        }

        public SearchPage(SearchService service)
        {
            InitializeComponent();
            context = new PhoneContext();
            this.service = service;
            vService = new ValidationServise();
        }

        SearchService service;
        ValidationServise vService;
        PhoneContext context;

        private void tRadioButton1_Checked(object sender, RoutedEventArgs e)
        {
            sTypeBox.Items.Clear();
            sTypeBox.Items.Add(new TextBlock() { Text = "по имени" });
            sTypeBox.Items.Add(new TextBlock() { Text = "по номеру" });
        }

        private void tRadioButton2_Checked(object sender, RoutedEventArgs e)
        {
            sTypeBox.Items.Clear();
            sTypeBox.Items.Add(new TextBlock() { Text = "по названию компании" });
            sTypeBox.Items.Add(new TextBlock() { Text = "по номеру" });
            sTypeBox.Items.Add(new TextBlock() { Text = "по роду деятельности" });
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Search(searchTextBox.Text, sTypeBox.SelectedIndex, (bool)tRadioButton1.IsChecked, 
                vService.SearchLineValid(searchTextBox.Text, errorLabel));
        }

        public void Search(string text, int selected, bool check, bool valid)
        {
            if (valid)
            {
                if (check)
                {
                    List<PersonalTelephone> list = service.SearchPersonal(text, selected);
                    service.FillGrid(personalGrid, corporativeGrid, errorLabel, resultLabel, list);
                }
                else
                {
                    List<CorporativeTelephone> list = service.SearchCorporative(text, selected);
                    service.FillGrid(personalGrid, corporativeGrid, errorLabel, resultLabel, list);
                }
            }
            
        }


        private void returnLink_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void sTypeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            errorLabel.Visibility = Visibility.Collapsed;
        }

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            errorLabel.Visibility = Visibility.Collapsed;
        }
    }
}
