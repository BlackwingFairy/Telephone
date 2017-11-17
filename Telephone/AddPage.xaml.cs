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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public AddPage()
        {
            InitializeComponent();
            
        }

        PhoneContext context = new PhoneContext();

        private void typeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (typeBox.SelectedIndex)
            {
                case 0:
                    surnameStack.Visibility = Visibility.Visible;
                    nameStack.Visibility = Visibility.Visible;
                    patronymicStack.Visibility = Visibility.Visible;
                    companyStack.Visibility = Visibility.Collapsed;
                    occupationStack.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    surnameStack.Visibility = Visibility.Collapsed;
                    nameStack.Visibility = Visibility.Collapsed;
                    patronymicStack.Visibility = Visibility.Collapsed;
                    companyStack.Visibility = Visibility.Visible;
                    occupationStack.Visibility = Visibility.Visible;
                    break;
                default:
                    surnameStack.Visibility = Visibility.Collapsed;
                    nameStack.Visibility = Visibility.Collapsed;
                    patronymicStack.Visibility = Visibility.Collapsed;
                    companyStack.Visibility = Visibility.Collapsed;
                    occupationStack.Visibility = Visibility.Collapsed;
                    break;
            }
            errorLabel.Visibility = Visibility.Collapsed;
        }

        private bool LengthValid(int start, int end, Label eLabel, TextBox textBox, string name)
        {
            if (textBox.Text.Length != 0)
            {
                if ((textBox.Text.Length<start) || (textBox.Text.Length > end))
                {
                    if (start != 0)
                    {
                        eLabel.Content = "Поле \"" + name + "\" должно содержать от " +start+" до "+end+" символов.";
                        
                    }
                    else
                    {
                        eLabel.Content = "В поле \""+name+ "\" нельзя вводить более "+end+" символов";
                    }
                    eLabel.Visibility = Visibility.Visible;
                    return false;
                }
                else
                {
                    eLabel.Visibility = Visibility.Collapsed;
                    return true;
                }

            }
            else
            {
                errorLabel.Content = "Все поля должны быть заполнены";
                errorLabel.Visibility = Visibility.Visible;
                return false;
            }
        }

        private void surnameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool flag = true;
            try
            {
                int test = Convert.ToInt16(surnameTextBox.Text);
            }
            catch (FormatException ex)
            {
                flag = false;
            }
            if (flag)
            {
                surnameTextBox.Clear();
            }
            errorLabel.Visibility = Visibility.Collapsed;
        }

        private void nameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool flag = true;
            try
            {
                int test = Convert.ToInt16(nameTextBox.Text);
            }
            catch (FormatException ex)
            {
                flag = false;
            }
            if (flag)
            {
                nameTextBox.Clear();
            }
            errorLabel.Visibility = Visibility.Collapsed;
        }

        private void patronymicTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool flag = true;
            try
            {
                int test = Convert.ToInt16(patronymicTextBox.Text);
            }
            catch (FormatException ex)
            {
                flag = false;
            }
            if (flag)
            {
                patronymicTextBox.Clear();
            }
            errorLabel.Visibility = Visibility.Collapsed;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            switch (typeBox.SelectedIndex)
            {
                case 0:
                    PersonalAdd();
                    break;
                case 1:
                    CorpAdd();
                    break;
                default:
                    errorLabel.Visibility = Visibility.Visible;
                    break;
            }
        }

        private bool isDublicate(int table, string number)
        {
            
            if (table == 0)
            {
                List<PersonalTelephone> result = context.PersPhone.Where(p => p.PhoneNumber == number).ToList();
                if (result.Count != 0)
                {
                    MessageBox.Show("Данный номер уже есть в базе", "Ошибка",  MessageBoxButton.OK);
                    return true;
                }
            }
            else
            {
                List<CorporativeTelephone> result = context.CorpPhones.Where(p => p.PhoneNumber == number).ToList();
                if (result.Count != 0)
                {
                    MessageBox.Show("Данный номер уже есть в базе", "Ошибка", MessageBoxButton.OK);
                    return true;
                }
            }
            
            return false;
        }

        private void PersonalAdd()
        {
            bool numValid = LengthValid(10, 20, numErrorLabel, numberTextBox, "Телефон");
            bool addrValid = LengthValid(0, 300, addrErrorLabel, addressTextBox, "Адрес");
            bool surValid = LengthValid(0, 20, surErrorLabel, surnameTextBox, "Фамилия");
            bool nameValid = LengthValid(0, 20, nameErrorLabel, nameTextBox, "Имя");
            bool patrValid = LengthValid(0, 20, patrErrorLabel, patronymicTextBox, "Отчество");

            if (numValid & addrValid & surValid & nameValid & patrValid & !isDublicate(0,numberTextBox.Text))
            {
                context.PersPhone.Add(new PersonalTelephone() {
                    PhoneNumber = numberTextBox.Text,
                    Address = addressTextBox.Text,
                    Surname = surnameTextBox.Text,
                    Name = nameTextBox.Text,
                    Patronymic = patronymicTextBox.Text
                });
                context.SaveChanges();
                MessageBox.Show("Добавление записи", "Данные успешно добавлены в базу.", MessageBoxButton.OK);
            }
        }


        private void CorpAdd()
        {
            bool numValid = LengthValid(10, 20, numErrorLabel, numberTextBox, "Телефон");
            bool addrValid = LengthValid(0, 300, addrErrorLabel, addressTextBox, "Адрес");
            bool compValid = LengthValid(0, 100, compErrorLabel, companyTextBox, "Название компании");
            bool occupValid = occupationBox.SelectedIndex != -1;

            if (numValid & addrValid & compValid & occupValid & !isDublicate(1, numberTextBox.Text))
            {
                context.CorpPhones.Add(new CorporativeTelephone()
                {
                    PhoneNumber = numberTextBox.Text,
                    Address = addressTextBox.Text,
                    Company = companyTextBox.Text,
                    Occupation = occupationBox.Text
                });
                context.SaveChanges();
                MessageBox.Show("Добавление записи", "Данные успешно добавлены в базу.", MessageBoxButton.OK);
            }
        }

        private void returnLink_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void oTypeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            errorLabel.Visibility = Visibility.Collapsed;
        }

        
    }
}
