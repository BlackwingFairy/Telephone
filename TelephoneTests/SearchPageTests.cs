using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telephone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephone.Tests
{
    [TestClass()]
    public class SearchPageTests
    {
        [TestMethod()]
        public void SearchLineValidMaxLengthTest()
        {
            PrivateObject obj = new PrivateObject(typeof(SearchPage));
            bool result = Convert.ToBoolean(obj.Invoke("searchLineValid", "searchsearchsearchsearch"));
            Assert.AreEqual(result, false);
        }

        [TestMethod()]
        public void SearchLineValidAllowedLengthTest()
        {
            PrivateObject obj = new PrivateObject(typeof(SearchPage));
            bool result = Convert.ToBoolean(obj.Invoke("searchLineValid", "search"));
            Assert.AreEqual(result, true);
        }

        [TestMethod()]
        public void SearchLineValidIsEmptyTest()
        {
            PrivateObject obj = new PrivateObject(typeof(SearchPage));
            bool result = Convert.ToBoolean(obj.Invoke("searchLineValid", ""));
            Assert.AreEqual(result, false);
        }
    }
}