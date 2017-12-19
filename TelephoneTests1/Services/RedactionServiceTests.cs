using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telephone.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Telephone.Models;
using System.Windows;
using Moq;
using System.Data.Entity;

namespace Telephone.Services.Tests
{
    [TestClass()]
    public class RedactionServiceTests
    {
        [TestMethod()]
        public void GetPhone_pGridVisible_Selected_ReturnsPersonalAndNull()
        {
            List<PersonalTelephone> sourse = new List<PersonalTelephone>()
            {
                new PersonalTelephone { PhoneNumber = "1234567890123" }
            };
            DataGrid pGrid = new DataGrid() { ItemsSource = sourse, SelectedItem = sourse[0], Visibility = Visibility.Visible};
            DataGrid cGrid = new DataGrid();
            RedactionService service = new RedactionService();            
            RedactionData result = service.GetPhone(pGrid, cGrid);
            Assert.AreEqual(sourse[0], result.Phone);
            Assert.AreEqual(0, result.Table);
        }

        [TestMethod()]
        public void GetPhone_pGridVisible_NotSelected_ReturnsNullAndNull()
        {
            List<PersonalTelephone> sourse = new List<PersonalTelephone>()
            {
                new PersonalTelephone { PhoneNumber = "1234567890123" }
            };
            DataGrid pGrid = new DataGrid() { ItemsSource = sourse, SelectedItem = null, Visibility = Visibility.Visible };
            DataGrid cGrid = new DataGrid();
            RedactionService service = new RedactionService();
            RedactionData result = service.GetPhone(pGrid, cGrid);
            Assert.IsNull(result.Phone);
            Assert.AreEqual(0, result.Table);
        }

        [TestMethod()]
        public void GetPhone_pGridNotVisible_Selected_ReturnsCorporativeAndOne()
        {
            List<CorporativeTelephone> sourse = new List<CorporativeTelephone>()
            {
                new CorporativeTelephone { PhoneNumber = "1234567890123" }
            };
            DataGrid pGrid = new DataGrid() { Visibility = Visibility.Collapsed };
            DataGrid cGrid = new DataGrid() { ItemsSource = sourse, SelectedItem = sourse[0] };
            RedactionService service = new RedactionService();
            RedactionData result = service.GetPhone(pGrid, cGrid);
            Assert.AreEqual(sourse[0], result.Phone);
            Assert.AreEqual(1, result.Table);
        }

        [TestMethod()]
        public void GetPhone_pGridNotVisible_NotSelected_ReturnsNullAndOne()
        {
            List<CorporativeTelephone> sourse = new List<CorporativeTelephone>()
            {
                new CorporativeTelephone { PhoneNumber = "1234567890123" }
            };
            DataGrid pGrid = new DataGrid() { Visibility = Visibility.Collapsed };
            DataGrid cGrid = new DataGrid() { ItemsSource = sourse, SelectedItem = null };
            RedactionService service = new RedactionService();
            RedactionData result = service.GetPhone(pGrid, cGrid);
            Assert.IsNull(result.Phone);
            Assert.AreEqual(0, result.Table);
        }

        [TestMethod()]
        public void PersonalRedaction_ValidData_RedactionSaved()
        {
            var mockSet = new Mock<DbSet<PersonalTelephone>>();
            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.PersPhone).Returns(mockSet.Object);
            mockSet.Setup(m => m.Find(It.IsAny<int>())).Returns(new PersonalTelephone { PhoneNumber = "1234567890000", Id = 5 });

            RedactionService service = new RedactionService(mockContext.Object);
            service.PersonalRedaction(new PersonalTelephone(), new Data(), true);

            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod()]
        public void PersonalRedaction_NotValidData_RedactionSaved()
        {
            var mockSet = new Mock<DbSet<PersonalTelephone>>();
            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.PersPhone).Returns(mockSet.Object);
            mockSet.Setup(m => m.Find(It.IsAny<int>())).Returns(new PersonalTelephone { PhoneNumber = "1234567890000", Id = 5 });

            RedactionService service = new RedactionService(mockContext.Object);
            service.PersonalRedaction(new PersonalTelephone(), new Data(), false);

            mockContext.Verify(m => m.SaveChanges(), Times.Never());
        }

        [TestMethod()]
        public void CorpRedaction_ValidData_RedactionSaved()
        {
            var mockSet = new Mock<DbSet<CorporativeTelephone>>();
            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.CorpPhones).Returns(mockSet.Object);
            mockSet.Setup(m => m.Find(It.IsAny<int>())).Returns(new CorporativeTelephone { PhoneNumber = "1234567890000", Id = 5 });

            RedactionService service = new RedactionService(mockContext.Object);
            service.CorpRedaction(new CorporativeTelephone(), new Data(), true);

            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod()]
        public void CorpRedaction_NotValidData_RedactionSaved()
        {
            var mockSet = new Mock<DbSet<CorporativeTelephone>>();
            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.CorpPhones).Returns(mockSet.Object);
            mockSet.Setup(m => m.Find(It.IsAny<int>())).Returns(new CorporativeTelephone { PhoneNumber = "1234567890000", Id = 5 });

            RedactionService service = new RedactionService(mockContext.Object);
            service.CorpRedaction(new CorporativeTelephone(), new Data(), false);

            mockContext.Verify(m => m.SaveChanges(), Times.Never());
        }
    }
}