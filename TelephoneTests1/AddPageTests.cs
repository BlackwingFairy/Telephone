using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telephone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephone.Models;
using Moq;
using System.Data.Entity;

namespace Telephone.Tests
{
    [TestClass()]
    public class AddPageTests
    {
        [TestMethod()]
        public void LengthValid_StartNotNull_InvalidLength_ReturnFalse()
        {
            PrivateObject obj = new PrivateObject(typeof(AddPage));
            int start = 1;
            int end = 6;
            Object eLabel = obj.GetField("testLabel");
            string text = "Textttt";
            string name = "Имя";
            bool result = Convert.ToBoolean(obj.Invoke("LengthValid", new object[] { start, end, eLabel, eLabel, text, name }));
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void LengthValid_StartNull_InvalidLength_ReturnFalse()
        {
            PrivateObject obj = new PrivateObject(typeof(AddPage));
            int start = 0;
            int end = 6;
            Object eLabel = obj.GetField("testLabel");
            string text = "Textttt";
            string name = "Имя";
            bool result = Convert.ToBoolean(obj.Invoke("LengthValid", new object[] { start, end, eLabel, eLabel, text, name }));
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void LengthValid_StartNull_ValidLength_ReturnFalse()
        {
            PrivateObject obj = new PrivateObject(typeof(AddPage));
            int start = 0;
            int end = 6;
            Object eLabel = obj.GetField("testLabel");
            string text = "Text";
            string name = "Имя";
            bool result = Convert.ToBoolean(obj.Invoke("LengthValid", new object[] { start, end, eLabel, eLabel, text, name }));
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void LengthValid_StartNull_EmptyString_ReturnFalse()
        {
            PrivateObject obj = new PrivateObject(typeof(AddPage));
            int start = 0;
            int end = 6;
            Object eLabel = obj.GetField("testLabel");
            string text = "";
            string name = "Имя";
            bool result = Convert.ToBoolean(obj.Invoke("LengthValid", new object[] { start, end, eLabel, eLabel, text, name }));
            Assert.IsFalse(result);
        }

        
        

       
        
    }
}