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
    public class DeleteService
    {
        PhoneContext context;
        public DeleteService(PhoneContext context)
        {
            this.context = context;
        }

        public DataGrid DeletePersonal(DataGrid pGrid)
        {
            if (pGrid.SelectedItem != null)
            {
                PersonalTelephone phone = pGrid.SelectedItem as PersonalTelephone;
                PersonalTelephone del = context.PersPhone.Find(phone.Id);
                if (del != null)
                {
                    var result = MessageBox.Show("Вы действительно хотите удалить эту запись?", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        context.PersPhone.Remove(del);
                        context.SaveChanges();
                    }
                }
            }            
            pGrid.ItemsSource = context.PersPhone.ToList();
            return pGrid;
        }

        public DataGrid DeleteCorporative(DataGrid cGrid)
        {
            if (cGrid.SelectedItem != null)
            {
                CorporativeTelephone phone = cGrid.SelectedItem as CorporativeTelephone;
                CorporativeTelephone del = context.CorpPhones.Find(phone.Id);
                if (del != null)
                {
                    var result = MessageBox.Show("Вы действительно хотите удалить эту запись?", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        context.CorpPhones.Remove(del);
                        context.SaveChanges();
                    }
                }
            }            
            cGrid.ItemsSource = context.CorpPhones.ToList();
            return cGrid;
        }
    }
}
