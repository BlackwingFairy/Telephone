using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Telephone.Models;

namespace Telephone.Services
{
    public class RedactionService
    {
        PhoneContext context;


        public RedactionService(){}
        public RedactionService(PhoneContext context)
        {
            this.context = context;
        }

        public RedactionData GetPhone(DataGrid pGrid, DataGrid cGrid)
        {
            Phone phone = null;
            int table = 0;
            if (pGrid.Visibility == Visibility.Visible)
            {
                if (pGrid.SelectedItem != null)
                {
                    phone = pGrid.SelectedItem as PersonalTelephone;
                    table = 0;
                }
            }
            else
            {
                if (cGrid.SelectedItem != null)
                {
                    phone = cGrid.SelectedItem as CorporativeTelephone;
                    table = 1;
                }
            }
            return new RedactionData() { Phone = phone, Table = table };
        }

        public void PersonalRedaction(PersonalTelephone phone, Data data, bool valid)
        {
            if (valid)
            {
                PersonalTelephone redPhone = context.PersPhone.Find(phone.Id);
                redPhone.PhoneNumber = data.Number;
                redPhone.Address = data.Address;
                redPhone.Surname = data.Surname;
                redPhone.Name = data.Name;
                redPhone.Patronymic = data.Patronymic;
                context.SaveChanges();
                MessageBox.Show("Изменения успешно добавлены в базу.", "Редактирование записи", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Ошибка при внесении изменений.", "Редактирование записи", MessageBoxButton.OK);
            }
        }


        public void CorpRedaction(CorporativeTelephone phone, Data data, bool valid)
        {
            if (valid)
            {
                CorporativeTelephone redPhone = context.CorpPhones.Find(phone.Id);

                redPhone.PhoneNumber = data.Number;
                redPhone.Address = data.Address;
                redPhone.Occupation = data.Occupation;
                redPhone.Company = data.Company;

                context.SaveChanges();
                MessageBox.Show("Изменения успешно добавлены в базу.", "Редактирование записи", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Ошибка при внесении изменений.", "Редактирование записи", MessageBoxButton.OK);
            }
        }

    }
}
