using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telephone.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephone.Models;
using System.Data.Entity;
using Moq;
using System.Windows.Controls;
using System.Windows;

namespace Telephone.Services.Tests
{
    [TestClass()]
    public class SearchServiceTests
    {
        [TestMethod()]
        public void SearchCorporative_SelectedNull_FindByCompany()
        {
            var data1 = new List<CorporativeTelephone>
            {
                new CorporativeTelephone { PhoneNumber = "1234567890000" },
                new CorporativeTelephone { Company = "company" },
                new CorporativeTelephone { Occupation = "IT" }
            }.AsQueryable();

            var mockSetC = new Mock<DbSet<CorporativeTelephone>>();
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.Provider).Returns(data1.Provider);
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.Expression).Returns(data1.Expression);
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.ElementType).Returns(data1.ElementType);
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.GetEnumerator()).Returns(data1.GetEnumerator());

            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.CorpPhones).Returns(mockSetC.Object);

            SearchService service = new SearchService(mockContext.Object);
            List<CorporativeTelephone> result = service.SearchCorporative("company", 0);
            Assert.AreEqual("company", result[0].Company);            
        }

        [TestMethod()]
        public void SearchCorporative_SelectedOne_FindByNumber()
        {
            var data1 = new List<CorporativeTelephone>
            {
                new CorporativeTelephone { PhoneNumber = "1234567890000" },
                new CorporativeTelephone { Company = "company" },
                new CorporativeTelephone { Occupation = "IT" }
            }.AsQueryable();

            var mockSetC = new Mock<DbSet<CorporativeTelephone>>();
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.Provider).Returns(data1.Provider);
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.Expression).Returns(data1.Expression);
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.ElementType).Returns(data1.ElementType);
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.GetEnumerator()).Returns(data1.GetEnumerator());

            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.CorpPhones).Returns(mockSetC.Object);

            SearchService service = new SearchService(mockContext.Object);
            List<CorporativeTelephone> result = service.SearchCorporative("1234567890000", 1);
            Assert.AreEqual("1234567890000", result[0].PhoneNumber);
        }

        [TestMethod()]
        public void SearchCorporative_SelectedTwo_FindByOccupation()
        {
            var data1 = new List<CorporativeTelephone>
            {
                new CorporativeTelephone { PhoneNumber = "1234567890000" },
                new CorporativeTelephone { Company = "company" },
                new CorporativeTelephone { Occupation = "IT" }
            }.AsQueryable();

            var mockSetC = new Mock<DbSet<CorporativeTelephone>>();
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.Provider).Returns(data1.Provider);
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.Expression).Returns(data1.Expression);
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.ElementType).Returns(data1.ElementType);
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.GetEnumerator()).Returns(data1.GetEnumerator());

            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.CorpPhones).Returns(mockSetC.Object);

            SearchService service = new SearchService(mockContext.Object);
            List<CorporativeTelephone> result = service.SearchCorporative("IT", 2);
            Assert.AreEqual("IT", result[0].Occupation);
        }

        [TestMethod()]
        public void SearchCorporative_NotSelected_NotFound()
        {
            var data1 = new List<CorporativeTelephone>
            {
                new CorporativeTelephone { PhoneNumber = "1234567890000" },
                new CorporativeTelephone { Company = "company" },
                new CorporativeTelephone { Occupation = "IT" }
            }.AsQueryable();

            var mockSetC = new Mock<DbSet<CorporativeTelephone>>();
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.Provider).Returns(data1.Provider);
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.Expression).Returns(data1.Expression);
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.ElementType).Returns(data1.ElementType);
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.GetEnumerator()).Returns(data1.GetEnumerator());

            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.CorpPhones).Returns(mockSetC.Object);

            SearchService service = new SearchService(mockContext.Object);
            List<CorporativeTelephone> result = service.SearchCorporative("IT", -1);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod()]
        public void SearchPersonal_SelectedNull_FindByName()
        {
            var data1 = new List<PersonalTelephone>
            {
                new PersonalTelephone { PhoneNumber = "1234567890000" },
                new PersonalTelephone { Name = "name" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<PersonalTelephone>>();
            mockSet.As<IQueryable<PersonalTelephone>>().Setup(m => m.Provider).Returns(data1.Provider);
            mockSet.As<IQueryable<PersonalTelephone>>().Setup(m => m.Expression).Returns(data1.Expression);
            mockSet.As<IQueryable<PersonalTelephone>>().Setup(m => m.ElementType).Returns(data1.ElementType);
            mockSet.As<IQueryable<PersonalTelephone>>().Setup(m => m.GetEnumerator()).Returns(data1.GetEnumerator());

            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.PersPhone).Returns(mockSet.Object);

            SearchService service = new SearchService(mockContext.Object);
            List<PersonalTelephone> result = service.SearchPersonal("name", 0);
            Assert.AreEqual("name", result[0].Name);
        }

        [TestMethod()]
        public void SearchPersonal_SelectedOne_FindByNumber()
        {
            var data1 = new List<PersonalTelephone>
            {
                new PersonalTelephone { PhoneNumber = "1234567890000" },
                new PersonalTelephone { Name = "name" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<PersonalTelephone>>();
            mockSet.As<IQueryable<PersonalTelephone>>().Setup(m => m.Provider).Returns(data1.Provider);
            mockSet.As<IQueryable<PersonalTelephone>>().Setup(m => m.Expression).Returns(data1.Expression);
            mockSet.As<IQueryable<PersonalTelephone>>().Setup(m => m.ElementType).Returns(data1.ElementType);
            mockSet.As<IQueryable<PersonalTelephone>>().Setup(m => m.GetEnumerator()).Returns(data1.GetEnumerator());

            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.PersPhone).Returns(mockSet.Object);

            SearchService service = new SearchService(mockContext.Object);
            List<PersonalTelephone> result = service.SearchPersonal("1234567890000", 1);
            Assert.AreEqual("1234567890000", result[0].PhoneNumber);
        }

        [TestMethod()]
        public void SearchPersonal_NotSelected_NotFound()
        {
            var data1 = new List<PersonalTelephone>
            {
                new PersonalTelephone { PhoneNumber = "1234567890000" },
                new PersonalTelephone { Name = "name" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<PersonalTelephone>>();
            mockSet.As<IQueryable<PersonalTelephone>>().Setup(m => m.Provider).Returns(data1.Provider);
            mockSet.As<IQueryable<PersonalTelephone>>().Setup(m => m.Expression).Returns(data1.Expression);
            mockSet.As<IQueryable<PersonalTelephone>>().Setup(m => m.ElementType).Returns(data1.ElementType);
            mockSet.As<IQueryable<PersonalTelephone>>().Setup(m => m.GetEnumerator()).Returns(data1.GetEnumerator());

            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.PersPhone).Returns(mockSet.Object);

            SearchService service = new SearchService(mockContext.Object);
            List<PersonalTelephone> result = service.SearchPersonal("1234567890000", -1);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod()]
        public void FillGrid_ItemsCountNotNull_FillGrid()
        {
            var data = new List<PersonalTelephone>
            {
                new PersonalTelephone { PhoneNumber = "1234567890000" }
            };
            SearchService service = new SearchService();
            DataGrid gridToFill = new DataGrid();
            DataGrid gridToClose = new DataGrid();
            Label rLabel = new Label();
            Label eLabel = new Label();
            service.FillGrid(gridToFill, gridToClose, eLabel, rLabel, data);
            Assert.AreEqual(data, gridToFill.ItemsSource);
        }

        [TestMethod()]
        public void FillGrid_ItemsCountNull_resultLabelNotVisible()
        {
            var data = new List<PersonalTelephone>
            {
                new PersonalTelephone { PhoneNumber = "1234567890000" }
            };
            SearchService service = new SearchService();
            DataGrid gridToFill = new DataGrid();
            DataGrid gridToClose = new DataGrid();
            Label rLabel = new Label() { Visibility = Visibility.Collapsed};
            Label eLabel = new Label() { Visibility = Visibility.Visible};
            service.FillGrid(gridToFill, gridToClose, eLabel, rLabel, data);
            Assert.AreEqual(Visibility.Collapsed, rLabel.Visibility);
        }

        [TestMethod()]
        public void FillGrid_ItemsCountNull_resultLabelVisible()
        {
            var data = new List<PersonalTelephone>
            {
                new PersonalTelephone { PhoneNumber = "1234567890000" }
            };
            SearchService service = new SearchService();
            DataGrid gridToFill = new DataGrid();
            DataGrid gridToClose = new DataGrid();
            Label rLabel = new Label() { Visibility = Visibility.Collapsed };
            Label eLabel = new Label() { Visibility = Visibility.Collapsed };
            service.FillGrid(gridToFill, gridToClose, eLabel, rLabel, data);
            Assert.AreEqual(Visibility.Collapsed, rLabel.Visibility);
        }
    }
}