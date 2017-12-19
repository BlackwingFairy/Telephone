using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telephone.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Telephone.Services.Tests
{
    [TestClass()]
    public class ValidationServiseTests
    {
        [TestMethod()]
        public void LengthValid_StartNotNull_InvalidLength_ReturnFalse()
        {
            int start = 1;
            int end = 6;
            Label eLabel = new Label();
            string text = "Textttt";
            string name = "Имя";
            ValidationServise service = new ValidationServise();
            bool result = service.LengthValid(start, end, eLabel, text, name);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void LengthValid_StartNull_InvalidLength_ReturnFalse()
        {
            int start = 0;
            int end = 6;
            Label eLabel = new Label();
            string text = "Textttt";
            string name = "Имя";
            ValidationServise service = new ValidationServise();
            bool result = service.LengthValid(start, end, eLabel, text, name);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void LengthValid_StartNull_ValidLength_ReturnFalse()
        {
            int start = 0;
            int end = 6;
            Label eLabel = new Label();
            string text = "Text";
            string name = "Имя";
            ValidationServise service = new ValidationServise();
            bool result = service.LengthValid(start, end, eLabel, text, name);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void LengthValid_StartNull_EmptyString_ReturnFalse()
        {
            int start = 0;
            int end = 6;
            Label eLabel = new Label();
            string text = "";
            string name = "Имя";
            ValidationServise service = new ValidationServise(new Label());
            bool result = service.LengthValid(start, end, eLabel, text, name);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void LoginValidation_NullLength_ReturnFalse()
        {
            ValidationServise service = new ValidationServise();
            bool result = service.LoginValidation("", new Label(), new Label(), 10);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void LoginValidation_LessLength_ReturnFalse()
        {
            ValidationServise service = new ValidationServise();
            bool result = service.LoginValidation("a", new Label(), new Label(), 10);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void LoginValidation_MoreLength_ReturnFalse()
        {
            ValidationServise service = new ValidationServise();
            bool result = service.LoginValidation("123456789012345678901", new Label(), new Label(), 10);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void LoginValidation_ValidLength_ReturnTrue()
        {
            ValidationServise service = new ValidationServise();
            bool result = service.LoginValidation("login", new Label(), new Label(), 10);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void PasswordValidation_NullLength_ReturnFalse()
        {
            ValidationServise service = new ValidationServise();
            bool result = service.PasswordValidation("", new Label(), new Label(), 10);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void PasswordValidation_LessLength_ReturnFalse()
        {
            ValidationServise service = new ValidationServise();
            bool result = service.PasswordValidation("a", new Label(), new Label(), 10);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void PasswordValidation_MoreLength_ReturnFalse()
        {
            ValidationServise service = new ValidationServise();
            bool result = service.PasswordValidation("123456789012345678901", new Label(), new Label(), 10);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void PasswordValidation_ValidLength_ReturnTrue()
        {
            ValidationServise service = new ValidationServise();
            bool result = service.PasswordValidation("login", new Label(), new Label(), 10);
            Assert.IsTrue(result);
        }
        

        [TestMethod()]
        public void СanEnter_ValidLogin_ValidPassword_ReturnTrue()
        {
            ValidationServise service = new ValidationServise();
            bool result = service.СanEnter("admin", "admin", new Label(), 10);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void СanEnter_NotValidLogin_ValidPassword_ReturnFalse()
        {
            ValidationServise service = new ValidationServise();
            bool result = service.СanEnter("adminn", "admin", new Label(), 10);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void СanEnter_ValidLogin_NotValidPassword_ReturnFalse()
        {
            ValidationServise service = new ValidationServise();
            bool result = service.СanEnter("admin", "adminn", new Label(), 10);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void СanEnter_NotValidLogin_NotValidPassword_ReturnFalse()
        {
            ValidationServise service = new ValidationServise();
            bool result = service.СanEnter("adminn", "adminn", new Label(), 10);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void SearchLineValid_MoreLength_ReturnFalse()
        {
            ValidationServise service = new ValidationServise();
            bool result = service.SearchLineValid("123456789012345678901", new Label());
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void SearchLineValid_ValidLength_ReturnTrue()
        {
            ValidationServise service = new ValidationServise();
            bool result = service.SearchLineValid("123456", new Label());
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void SearchLineValid_NullLength_ReturnFalse()
        {
            ValidationServise service = new ValidationServise();
            bool result = service.SearchLineValid("", new Label());
            Assert.IsFalse(result);
        }
    }
}