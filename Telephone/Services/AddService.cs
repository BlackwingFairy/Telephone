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
    public class AddService
    {
        PhoneContext context;
        public AddService(PhoneContext context)
        {
            this.context = context;
        }
        public void AddPhone(int selected, bool dublicate, Data data, bool valid)
        {
            if (!dublicate && valid)
            {
                switch (selected)
                {
                    case 0:
                        PersonalAdd(data);
                        break;
                    case 1:
                        CorpAdd(data);
                        break;
                    default:
                        break;
                }
            }
        }

        public virtual Phone PersonalAdd(Data data)
        {

            Phone added = new PersonalTelephone()
            {
                PhoneNumber = data.Number,
                Address = data.Address,
                Surname = data.Surname,
                Name = data.Name,
                Patronymic = data.Patronymic
            };
            context.PersPhone.Add((PersonalTelephone)added);
            context.SaveChanges();
            MessageBox.Show("Добавление записи", "Данные успешно добавлены в базу.", MessageBoxButton.OK);
            return added;

        }


        public virtual Phone CorpAdd(Data data)
        {
            Phone added = new CorporativeTelephone()
            {
                PhoneNumber = data.Number,
                Address = data.Address,
                Company = data.Company,
                Occupation = data.Occupation
            };
            context.CorpPhones.Add((CorporativeTelephone)added);
            context.SaveChanges();
            MessageBox.Show("Добавление записи", "Данные успешно добавлены в базу.", MessageBoxButton.OK);
            return added;
        }

        public bool IsDublicate(string number)
        {


            List<PersonalTelephone> result1 = context.PersPhone.Where(p => p.PhoneNumber == number).ToList();
            if (result1.Count != 0)
            {
                MessageBox.Show("Данный номер уже есть в базе", "Ошибка", MessageBoxButton.OK);
                return true;
            }

            List<CorporativeTelephone> result2 = context.CorpPhones.Where(p => p.PhoneNumber == number).ToList();
            if (result2.Count != 0)
            {
                MessageBox.Show("Данный номер уже есть в базе", "Ошибка", MessageBoxButton.OK);
                return true;
            }


            return false;
        }
    }
}
