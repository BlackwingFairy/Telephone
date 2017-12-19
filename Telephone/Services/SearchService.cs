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
    public class SearchService
    {
        PhoneContext context;

        public SearchService(){}

        public SearchService(PhoneContext context)
        {
            this.context = context;
        }

        public virtual List<CorporativeTelephone> SearchCorporative(string text, int selected)
        {
            List<CorporativeTelephone> result = new List<CorporativeTelephone>();
            switch (selected)
            {
                case 0:
                    result = context.CorpPhones.Where(phone => phone.Company == text).ToList();
                    break;
                case 1:
                    result = context.CorpPhones.Where(phone => phone.PhoneNumber == text).ToList();
                    break;
                case 2:
                    result = context.CorpPhones.Where(phone => phone.Occupation == text).ToList();
                    break;
                default:
                    break;
            }
            return result;
        }

        public virtual List<PersonalTelephone> SearchPersonal(string text, int selected)
        {
            List<PersonalTelephone> result = new List<PersonalTelephone>();

            switch (selected)
            {
                case 0:
                    result = context.PersPhone.Where(phone => phone.Name == text).ToList();
                    result.AddRange(context.PersPhone.Where(phone => phone.Surname == text).ToList());
                    result.AddRange(context.PersPhone.Where(phone => phone.Patronymic == text).ToList());
                    break;
                case 1:
                    result = context.PersPhone.Where(phone => phone.PhoneNumber == text).ToList();
                    break;
                default:
                    break;
            }

            return result;
        }        

        public virtual void FillGrid(DataGrid gridToFill, DataGrid gridToClose, Label eLabel, Label rLabel, IEnumerable<Phone> list)
        {
            if (list.Count() != 0)
            {
                rLabel.Visibility = Visibility.Collapsed;
                gridToClose.Visibility = Visibility.Collapsed;
                gridToFill.Visibility = Visibility.Visible;

                gridToFill.ItemsSource = list;

            }
            else
            {
                gridToClose.Visibility = Visibility.Collapsed;
                gridToFill.Visibility = Visibility.Collapsed;
                if (eLabel.Visibility == Visibility.Collapsed)
                {
                    rLabel.Visibility = Visibility.Visible;
                }

            }
        }
    }
}
