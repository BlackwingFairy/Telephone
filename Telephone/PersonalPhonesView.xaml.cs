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
    /// Логика взаимодействия для PersonalPhonesView.xaml
    /// </summary>
    public partial class PersonalPhonesView : Page
    {
        public PersonalPhonesView()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PhoneContext db = new PhoneContext();
            personalGrid.ItemsSource = db.PersPhone.ToList<PersonalTelephone>();
        }
    }
}
