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
    /// Логика взаимодействия для CorporativePhonesView.xaml
    /// </summary>
    public partial class CorporativePhonesView : Page
    {
        public CorporativePhonesView()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PhoneContext db = new PhoneContext();
            corporativeGrid.ItemsSource = db.CorpPhones.ToList<CorporativeTelephone>();
        }
    }
}
