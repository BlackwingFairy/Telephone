using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telephone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using System.Windows;
using Telephone.Models;

namespace Telephone.Tests
{
    [TestClass()]
    public class AddPageTests
    {
        [TestMethod()]
        public void LengthValid_MoreOrLess_StartNotNull_Test()
        {
            PrivateObject obj = new PrivateObject(typeof(AddPage));
            int start = 1;
            int end = 6;
            string text = "Textttt";
            string name = "Name";
            Object label = obj.GetField("TestLabel");
            
            bool result = Convert.ToBoolean(obj.Invoke("LengthValid",new Object[]{ start, end, label, text, name}));
            Assert.AreEqual(result, false);
        }

        [TestMethod()]
        public void LengthValid_MoreOrLess_StartNull_Test()
        {
            PrivateObject obj = new PrivateObject(typeof(AddPage));
            int start = 0;
            int end = 6;
            string text = "Textttt";
            string name = "Name";
            Object label = obj.GetField("TestLabel");

            bool result = Convert.ToBoolean(obj.Invoke("LengthValid", new Object[] { start, end, label, text, name }));
            Assert.AreEqual(result, false);
        }

        [TestMethod()]
        public void LengthValid_AllowedLength_Test()
        {
            PrivateObject obj = new PrivateObject(typeof(AddPage));
            int start = 0;
            int end = 6;
            string text = "Text";
            string name = "Name";
            Object label = obj.GetField("TestLabel");

            bool result = Convert.ToBoolean(obj.Invoke("LengthValid", new Object[] { start, end, label, text, name }));
            Assert.AreEqual(result, true);
        }

        [TestMethod()]
        public void LengthValid_EmptyText_Test()
        {
            PrivateObject obj = new PrivateObject(typeof(AddPage));
            int start = 0;
            int end = 6;
            string text = "";
            string name = "Name";
            Object label = obj.GetField("TestLabel");

            bool result = Convert.ToBoolean(obj.Invoke("LengthValid", new Object[] { start, end, label, text, name }));
            Assert.AreEqual(result, false);
        }

        [TestMethod()]
        public void Add_SelectedFirst_Test()
        {
            //numberTextBox.Text = "11111111111";
            //addressTextBox.Text = "address";
            //surnameTextBox.Text = "yakovchits";
            //nameTextBox.Text = "ksenia";
            //patronymicTextBox.Text = "olegovna";
            //companyTextBox.Text = "company";
            //occupationBox.SelectedIndex = 0;
            
            PrivateObject obj = new PrivateObject(typeof(AddPage));
            obj.Invoke("TestFields");
            
            PersonalTelephone tel = new PersonalTelephone()
            {
                Name = "ksenia",
                Surname = "yakovchits",
                PhoneNumber = "11111111111",
                Address = "address",
                Patronymic = "yakovchits"
            };

            PersonalTelephone result = (PersonalTelephone)obj.Invoke("Add", new Object[] {0});
            Assert.AreEqual(result.Name, tel.Name);
            Assert.AreEqual(result.Surname, tel.Surname);
            Assert.AreEqual(result.PhoneNumber, tel.PhoneNumber);
            Assert.AreEqual(result.Address, tel.Address);
            Assert.AreEqual(result.Patronymic, tel.Patronymic);
        }
    }
}