using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telephone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephone.Models;

namespace Telephone.Tests
{
    [TestClass()]
    public class SearchPageTests
    {
        [TestMethod()]
        public void SearchLineValid_BiggerLength_ReturnFalse()
        {
            PrivateObject obj = new PrivateObject(typeof(SearchPage));
            bool result = Convert.ToBoolean(obj.Invoke("SearchLineValid", "searchsearchsearchsearch"));
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void SearchLineValid_ValidLength_ReturnTrue()
        {
            PrivateObject obj = new PrivateObject(typeof(SearchPage));
            bool result = Convert.ToBoolean(obj.Invoke("SearchLineValid", "search"));
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void SearchLineValid_NullLength_ReturnFalse()
        {
            PrivateObject obj = new PrivateObject(typeof(SearchPage));
            bool result = Convert.ToBoolean(obj.Invoke("SearchLineValid", ""));
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Search_Checked_SelectedNull_ValidText_ReturnListLengthNotNull()
        {
            PrivateObject obj = new PrivateObject(typeof(SearchPage));
            string search = "Яковчиц";
            int selected = 0;
            bool check = true;
            List<PersonalTelephone> result = (List<PersonalTelephone>)obj.Invoke("Search", new object[] { search, selected, check });
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public void Search_Checked_SelectedNull_ValidText_ReturnListLengthNull()
        {
            PrivateObject obj = new PrivateObject(typeof(SearchPage));
            string search = "Яковчик";
            int selected = 0;
            bool check = true;
            List<PersonalTelephone> result = (List<PersonalTelephone>)obj.Invoke("Search", new object[] { search, selected, check });
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod()]
        public void Search_Checked_SelectedNull_NotValidText_ReturnListLengthNull()
        {
            PrivateObject obj = new PrivateObject(typeof(SearchPage));
            string search = "";
            int selected = 0;
            bool check = true;
            List<PersonalTelephone> result = (List<PersonalTelephone>)obj.Invoke("Search", new object[] { search, selected, check });
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod()]
        public void Search_NotChecked_SelectedNull_ValidText_ReturnListLengthNotNull()
        {
            PrivateObject obj = new PrivateObject(typeof(SearchPage));
            string search = "Slasti";
            int selected = 0;
            bool check = false;
            List<CorporativeTelephone> result = (List<CorporativeTelephone>)obj.Invoke("Search", new object[] { search, selected, check });
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public void Search_NotChecked_SelectedNull_ValidText_ReturnListLengthNull()
        {
            PrivateObject obj = new PrivateObject(typeof(SearchPage));
            string search = "Slast";
            int selected = 0;
            bool check = false;
            List<CorporativeTelephone> result = (List<CorporativeTelephone>)obj.Invoke("Search", new object[] { search, selected, check });
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod()]
        public void Search_NotChecked_SelectedNull_NotValidText_ReturnListLengthNull()
        {
            PrivateObject obj = new PrivateObject(typeof(SearchPage));
            string search = "";
            int selected = 0;
            bool check = false;
            List<CorporativeTelephone> result = (List<CorporativeTelephone>)obj.Invoke("Search", new object[] { search, selected, check });
            Assert.AreEqual(0, result.Count);
        }
    }
}