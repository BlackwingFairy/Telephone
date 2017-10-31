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
    /// Логика взаимодействия для DeletePage.xaml
    /// </summary>
    public partial class DeletePage : Page
    {
        public DeletePage()
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

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (personalGrid.Visibility == Visibility.Visible)
            {
                if (personalGrid.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < personalGrid.SelectedItems.Count; i++)
                    {
                       
                        
                        PersonalTelephone phone = personalGrid.SelectedItems[i] as PersonalTelephone;
                        PersonalTelephone del = db.PersPhone.Find(phone.Id);
                        if (del != null)
                        {
                            var result = MessageBox.Show("Вы действительно хотите удалить эту запись?", "Удаление",  MessageBoxButton.YesNo);
                            if (result == MessageBoxResult.Yes)
                            {
                                db.PersPhone.Remove(del);
                            }                            
                        }
                    }
                }
                db.SaveChanges();
                personalGrid.ItemsSource = db.PersPhone.ToList();

            }
            if (corporativeGrid.Visibility == Visibility.Visible)
            {
                if (corporativeGrid.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < corporativeGrid.SelectedItems.Count; i++)
                    {


                        CorporativeTelephone phone = personalGrid.SelectedItems[i] as CorporativeTelephone;
                        CorporativeTelephone del = db.CorpPhones.Find(phone.Id);
                        if (del != null)
                        {
                            var result = MessageBox.Show("Вы действительно хотите удалить эту запись?", "Удаление", MessageBoxButton.YesNo);
                            if (result == MessageBoxResult.Yes)
                            {
                                db.CorpPhones.Remove(del);
                            }
                        }
                    }
                }
                db.SaveChanges();
                corporativeGrid.ItemsSource = db.CorpPhones.ToList();

            }
        }
    }
    
}
