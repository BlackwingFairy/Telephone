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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public AddPage(PhoneContext context)
        {
            InitializeComponent();
            this.context = context;
            service = new AddService(context);
        }


        public AddPage()
        {
            InitializeComponent();
            context = new PhoneContext();
            service = new AddService(context);
        }


        PhoneContext context;
        AddService service;
        Label testLabel = new Label();
        

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

        private bool LengthValid(int start, int end, Label eLabel, Label empty, string textBox, string name)
        {
            if (textBox.Length != 0)
            {
                if ((textBox.Length<start) || (textBox.Length > end))
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
                empty.Content = "Все поля должны быть заполнены";
                empty.Visibility = Visibility.Visible;
                return false;
            }
        }

        public bool FieldsValidation(Data data, int selectedType)
        {
            switch (selectedType)
            {
                case 0:
                    bool numValidP = LengthValid(10, 20, numErrorLabel, errorLabel, data.Number, "Телефон");
                    bool addrValidP = LengthValid(0, 300, addrErrorLabel, errorLabel, data.Address, "Адрес");
                    bool surValid = LengthValid(0, 20, surErrorLabel, errorLabel, data.Surname, "Фамилия");
                    bool nameValid = LengthValid(0, 20, nameErrorLabel, errorLabel, data.Name, "Имя");
                    bool patrValid = LengthValid(0, 20, patrErrorLabel, errorLabel,data.Patronymic, "Отчество");
                    if (numValidP && addrValidP && surValid && nameValid && patrValid)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 1:
                    bool numValidC = LengthValid(10, 20, numErrorLabel, errorLabel, data.Number, "Телефон");
                    bool addrValidC = LengthValid(0, 300, addrErrorLabel, errorLabel, data.Address, "Адрес");
                    bool compValid = LengthValid(0, 100, compErrorLabel, errorLabel, data.Company, "Название компании");
                    bool occupValid = data.Occupation != null;

                    if (numValidC && addrValidC && compValid && occupValid)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
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
            Data data = new Data()
            {
                Name = nameTextBox.Text,
                Address = addressTextBox.Text,
                Company = companyTextBox.Text,
                Surname = surnameTextBox.Text,
                Patronymic = patronymicTextBox.Text,
                Occupation = occupationBox.Text,
                Number = numberTextBox.Text
            };
            bool valid = FieldsValidation(data,typeBox.SelectedIndex);
            service.AddPhone(typeBox.SelectedIndex, service.IsDublicate(numberTextBox.Text), data, valid);
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
