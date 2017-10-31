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
    /// Логика взаимодействия для ViewRedactionPage.xaml
    /// </summary>
    public partial class ViewRedactionPage : Page
    {
        public ViewRedactionPage()
        {
            InitializeComponent();
        }

        public object Phone { get; set; }
        public int T { get; set; }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            typeBox.SelectedIndex = T;
            if (T == 0)
            {
                PersonalTelephone phone = Phone as PersonalTelephone;
                numberTextBox.Text = phone.PhoneNumber;
                addressTextBox.Text = phone.Address;
                surnameTextBox.Text = phone.Surname;
                nameTextBox.Text = phone.Name;
                patronymicTextBox.Text = phone.Patronymic;
            }
            else
            {
                CorporativeTelephone phone = Phone as CorporativeTelephone;
                numberTextBox.Text = phone.PhoneNumber;
                addressTextBox.Text = phone.Address;
                companyTextBox.Text = phone.Company;
                occupationBox.Text = phone.Occupation;
            }
            
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
                if ((textBox.Text.Length < start) || (textBox.Text.Length > end))
                {
                    if (start != 0)
                    {
                        eLabel.Content = "Поле \"" + name + "\" должно содержать от " + start + " до " + end + " символов.";

                    }
                    else
                    {
                        eLabel.Content = "В поле \"" + name + "\" нельзя вводить более " + end + " символов";
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

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            switch (typeBox.SelectedIndex)
            {
                case 0:
                    PersonalRedaction(Phone as PersonalTelephone);
                    break;
                case 1:
                    CorpRedaction(Phone as CorporativeTelephone);
                    break;
                default:
                    errorLabel.Visibility = Visibility.Visible;
                    break;
            }
        }

        
        private void PersonalRedaction(PersonalTelephone phone)
        {
            bool numValid = LengthValid(10, 20, numErrorLabel, numberTextBox, "Телефон");
            bool addrValid = LengthValid(0, 300, addrErrorLabel, addressTextBox, "Адрес");
            bool surValid = LengthValid(0, 20, surErrorLabel, surnameTextBox, "Фамилия");
            bool nameValid = LengthValid(0, 20, nameErrorLabel, nameTextBox, "Имя");
            bool patrValid = LengthValid(0, 20, patrErrorLabel, patronymicTextBox, "Отчество");

            if (numValid & addrValid & surValid & nameValid & patrValid)
            {
                PersonalTelephone redPhone = context.PersPhone.Find(phone.Id);

                redPhone.PhoneNumber = numberTextBox.Text;
                redPhone.Address = addressTextBox.Text;
                redPhone.Surname = surnameTextBox.Text;
                redPhone.Name = nameTextBox.Text;
                redPhone.Patronymic = patronymicTextBox.Text;
                
                context.SaveChanges();
                var result = MessageBox.Show("Изменения успешно добавлены в базу.","Редактирование записи", MessageBoxButton.OK);
                if (result == MessageBoxResult.OK)
                {
                    NavigationService.GoBack();
                }
            }
        }


        private void CorpRedaction(CorporativeTelephone phone)
        {
            bool numValid = LengthValid(10, 20, numErrorLabel, numberTextBox, "Телефон");
            bool addrValid = LengthValid(0, 300, addrErrorLabel, addressTextBox, "Адрес");
            bool compValid = LengthValid(0, 100, compErrorLabel, companyTextBox, "Название компании");
            bool occupValid = occupationBox.SelectedIndex != -1;

            if (numValid & addrValid & compValid & occupValid)
            {
                CorporativeTelephone redPhone = context.CorpPhones.Find(phone.Id);

                redPhone.PhoneNumber = numberTextBox.Text;
                redPhone.Address = addressTextBox.Text;
                redPhone.Occupation = occupationBox.Text;
                redPhone.Company = companyTextBox.Text;                

                context.SaveChanges();
                var result = MessageBox.Show("Изменения успешно добавлены в базу.", "Редактирование записи", MessageBoxButton.OK);
                if (result == MessageBoxResult.OK)
                {
                    NavigationService.GoBack();
                }
            }
        }

       
        private void oTypeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            errorLabel.Visibility = Visibility.Collapsed;
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
