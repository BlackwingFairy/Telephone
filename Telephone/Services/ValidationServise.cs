using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Telephone.Services
{
    public class ValidationServise
    {
        Label empty;

        public ValidationServise()
        {            
        }

        public ValidationServise(Label empty)
        {
            this.empty = empty;
        }

        public bool LengthValid(int start, int end, Label eLabel, string text, string name)
        {
            if (text.Length != 0)
            {
                if ((text.Length < start) || (text.Length > end))
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
                empty.Content = "Все поля должны быть заполнены";
                empty.Visibility = Visibility.Visible;
                return false;
            }
        }

        public bool LoginValidation(string login, Label errorLabel, Label loginLabel, double eLabelWidth)
        {
            if (login.Length == 0)
            {
                loginLabel.Visibility = Visibility.Visible;
                return false;
            }

            if ((login.Length < 3) || (login.Length > 20))
            {
                errorLabel.Content = "Логин должен содержать от 3 до 20 символов";
                errorLabel.Width = eLabelWidth;
                errorLabel.Visibility = Visibility.Visible;
                return false;
            }
            return true;
        }

        public bool PasswordValidation(string password, Label errorLabel, Label passwordLabel, double eLabelWidth)
        {
            if (password.Length == 0)
            {
                passwordLabel.Visibility = Visibility.Visible;
                return false;
            }

            if ((password.Length < 3) || (password.Length > 20))
            {
                errorLabel.Content = "Пароль должен содержать от 3 до 20 символов";
                errorLabel.Width = eLabelWidth;
                errorLabel.Visibility = Visibility.Visible;
                return false;
            }

            return true;

        }

        public bool СanEnter(string login, string password, Label eLabel, double eLabelWidth)
        {
            if ((login == "admin") && (password == "admin"))
            {
                return true;
            }
            else
            {
                eLabel.Content = "Логин или пароль введены неверно!\nПопробуйте ещё раз!";
                eLabel.Width = eLabelWidth;
                eLabel.Visibility = Visibility.Visible;
                return false;
            }
        }

        public bool SearchLineValid(string text, Label errorLabel)
        {
            if (text.Length != 0)
            {
                if (text.Length > 20)
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
            else
            {
                errorLabel.Content = "Заполните все поля!";
                errorLabel.Visibility = Visibility.Visible;
                return false;
            }

        }
    }
}
