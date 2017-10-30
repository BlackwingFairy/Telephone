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
    /// Логика взаимодействия для SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        PhoneContext db = new PhoneContext();

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
            if (tRadioButton1.IsChecked == true)
            {
                List<PersonalTelephone> list = SearchPersonal();
                if (list.Count != 0)
                {
                    resultLabel.Visibility = Visibility.Collapsed;
                    corporativeGrid.Visibility = Visibility.Collapsed;
                    personalGrid.Visibility = Visibility.Visible;

                    personalGrid.ItemsSource = list;
                }
                else
                {
                    corporativeGrid.Visibility = Visibility.Collapsed;
                    personalGrid.Visibility = Visibility.Collapsed;
                    if (errorLabel.Visibility == Visibility.Collapsed)
                    {
                        resultLabel.Visibility = Visibility.Visible;
                    }
                    
                }
            }
            else
            {
                List<CorporativeTelephone> list = SearchCorporative();
                if (list.Count != 0)
                {
                    resultLabel.Visibility = Visibility.Collapsed;
                    personalGrid.Visibility = Visibility.Collapsed;
                    corporativeGrid.Visibility = Visibility.Visible;
                    
                    corporativeGrid.ItemsSource = list;
                }
                else
                {
                    corporativeGrid.Visibility = Visibility.Collapsed;
                    personalGrid.Visibility = Visibility.Collapsed;
                    if (errorLabel.Visibility == Visibility.Collapsed)
                    {
                        resultLabel.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        private bool searchLineValid()
        {
            if (searchTextBox.Text.Length > 20)
            {
                errorLabel.Content = "Запрос не может быть длиннее 20 символов!";
                errorLabel.Visibility = Visibility.Visible;
                return false;
            }
            else
            {
                return true;
            }
        }

        private List<PersonalTelephone> SearchPersonal()
        {
            List<PersonalTelephone> result = new List<PersonalTelephone>();
            switch (sTypeBox.SelectedIndex)
            {
                case 0:
                    result = db.PersPhone.Where(phone => phone.Name == searchTextBox.Text).ToList();
                    result.AddRange(db.PersPhone.Where(phone => phone.Surname == searchTextBox.Text).ToList());
                    result.AddRange(db.PersPhone.Where(phone => phone.Patronymic == searchTextBox.Text).ToList());
                    break;
                case 1:
                    result = db.PersPhone.Where(phone => phone.PhoneNumber == searchTextBox.Text).ToList();
                    break;
                default:
                    errorLabel.Visibility = Visibility.Visible;
                    break;
            }
            return result;
        }

        private List<CorporativeTelephone> SearchCorporative()
        {
            List<CorporativeTelephone> result = new List<CorporativeTelephone>();
            switch (sTypeBox.SelectedIndex)
            {
                case 0:
                    result = db.CorpPhones.Where(phone => phone.Company == searchTextBox.Text).ToList();
                    break;
                case 1:
                    result = db.CorpPhones.Where(phone => phone.PhoneNumber == searchTextBox.Text).ToList();
                    break;
                case 2:
                    result = db.CorpPhones.Where(phone => phone.Occupation == searchTextBox.Text).ToList();
                    break;
                default:
                    errorLabel.Visibility = Visibility.Visible;
                    break;
            }
            return result;
        }


        private void returnLink_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void sTypeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            errorLabel.Visibility = Visibility.Collapsed;
        }
    }
}
