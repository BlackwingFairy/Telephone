using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telephone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephone.Services;

namespace Telephone.Tests
{
    [TestClass()]
    public class ViewRedactionPageTests
    {
        [TestMethod()]
        public void FieldsValidation_SelectedNull_NotValidFields_ReturnFalse()
        {
            Data data = new Data
            {
                Number = "1234",
                Name = "name",
                Surname = "surname",
                Patronymic = "patronymic",
                Address = "address",
                Company = "Company",
                Occupation = "IT"
            };
            ViewRedactionPage page = new ViewRedactionPage();
            bool result = page.FieldsValidation(data, 0);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void FieldsValidation_SelectedNull_ValidFields_ReturnTrue()
        {
            Data data = new Data
            {
                Number = "1234567890000",
                Name = "name",
                Surname = "surname",
                Patronymic = "patronymic",
                Address = "address",
                Company = "Company",
                Occupation = "IT"
            };
            ViewRedactionPage page = new ViewRedactionPage();
            bool result = page.FieldsValidation(data, 0);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void FieldsValidation_SelectedOne_NotValidFields_ReturnFalse()
        {
            Data data = new Data
            {
                Number = "1234",
                Name = "name",
                Surname = "surname",
                Patronymic = "patronymic",
                Address = "address",
                Company = "Company",
                Occupation = "IT"
            };
            ViewRedactionPage page = new ViewRedactionPage();
            bool result = page.FieldsValidation(data, 1);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void FieldsValidation_SelectedOne_ValidFields_ReturnTrue()
        {
            Data data = new Data
            {
                Number = "1234567890000",
                Name = "name",
                Surname = "surname",
                Patronymic = "patronymic",
                Address = "address",
                Company = "Company",
                Occupation = "IT"
            };
            ViewRedactionPage page = new ViewRedactionPage();
            bool result = page.FieldsValidation(data, 0);
            Assert.IsTrue(result);
        }
    }
}