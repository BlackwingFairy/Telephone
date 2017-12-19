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

namespace Telephone.Services.Tests
{
    [TestClass()]
    public class DeleteServiceTests
    {        
        [TestMethod()]
        public void DeletePersonal_SelectedItem_Founded_ClickYes_Delete()
        {
            var list = new List<PersonalTelephone>
            {
                new PersonalTelephone { PhoneNumber = "1234567890000", Id = 5 }
            }.AsQueryable();

            DataGrid grid = new DataGrid() { ItemsSource = list, SelectedItem = list.FirstOrDefault()};         
            var mockSet = new Mock<DbSet<PersonalTelephone>>();
            mockSet.As<IQueryable<PersonalTelephone>>().Setup(m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable<PersonalTelephone>>().Setup(m => m.Expression).Returns(list.Expression);
            mockSet.As<IQueryable<PersonalTelephone>>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.As<IQueryable<PersonalTelephone>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());

            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.PersPhone).Returns(mockSet.Object);
            mockSet.Setup(m => m.Find(It.IsAny<int>())).Returns(new PersonalTelephone { PhoneNumber = "1234567890000", Id = 5 });
            
            DeleteService service = new DeleteService(mockContext.Object);
            service.DeletePersonal(grid);

            mockSet.Verify(m => m.Remove(It.IsAny<PersonalTelephone>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod()]
        public void DeletePersonal_SelectedItem_Founded_ClickNo_NotDelete()
        {
            var list = new List<PersonalTelephone>
            {
                new PersonalTelephone { PhoneNumber = "1234567890000", Id = 5 }
            }.AsQueryable();

            DataGrid grid = new DataGrid() { ItemsSource = list, SelectedItem = list.FirstOrDefault() };
            var mockSet = new Mock<DbSet<PersonalTelephone>>();
            mockSet.As<IQueryable<PersonalTelephone>>().Setup(m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable<PersonalTelephone>>().Setup(m => m.Expression).Returns(list.Expression);
            mockSet.As<IQueryable<PersonalTelephone>>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.As<IQueryable<PersonalTelephone>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());

            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.PersPhone).Returns(mockSet.Object);
            mockSet.Setup(m => m.Find(It.IsAny<int>())).Returns(new PersonalTelephone { PhoneNumber = "1234567890000", Id = 5 });

            DeleteService service = new DeleteService(mockContext.Object);
            service.DeletePersonal(grid);

            mockSet.Verify(m => m.Remove(It.IsAny<PersonalTelephone>()), Times.Never());
            mockContext.Verify(m => m.SaveChanges(), Times.Never());
        }

        [TestMethod()]
        public void DeletePersonal_SelectedItem_NotFounded_NotDelete()
        {
            PersonalTelephone n = null;
            var list = new List<PersonalTelephone>
            {
                new PersonalTelephone { PhoneNumber = "1234567890000", Id = 5 }
            }.AsQueryable();

            DataGrid grid = new DataGrid() { ItemsSource = list, SelectedItem = list.FirstOrDefault() };
            var mockSet = new Mock<DbSet<PersonalTelephone>>();
            mockSet.As<IQueryable<PersonalTelephone>>().Setup(m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable<PersonalTelephone>>().Setup(m => m.Expression).Returns(list.Expression);
            mockSet.As<IQueryable<PersonalTelephone>>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.As<IQueryable<PersonalTelephone>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());

            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.PersPhone).Returns(mockSet.Object);
            mockSet.Setup(m => m.Find(It.IsAny<int>())).Returns(n);

            DeleteService service = new DeleteService(mockContext.Object);
            service.DeletePersonal(grid);

            mockSet.Verify(m => m.Remove(It.IsAny<PersonalTelephone>()), Times.Never());
            mockContext.Verify(m => m.SaveChanges(), Times.Never());
        }

        [TestMethod()]
        public void DeleteCorporative_SelectedItem_Founded_ClickYes_Delete()
        {
            var list = new List<CorporativeTelephone>
            {
                new CorporativeTelephone { PhoneNumber = "1234567890000", Id = 5 }
            }.AsQueryable();

            DataGrid grid = new DataGrid() { ItemsSource = list, SelectedItem = list.FirstOrDefault() };
            var mockSet = new Mock<DbSet<CorporativeTelephone>>();
            mockSet.As<IQueryable<CorporativeTelephone>>().Setup(m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable<CorporativeTelephone>>().Setup(m => m.Expression).Returns(list.Expression);
            mockSet.As<IQueryable<CorporativeTelephone>>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.As<IQueryable<CorporativeTelephone>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());

            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.CorpPhones).Returns(mockSet.Object);
            mockSet.Setup(m => m.Find(It.IsAny<int>())).Returns(new CorporativeTelephone { PhoneNumber = "1234567890000", Id = 5 });

            DeleteService service = new DeleteService(mockContext.Object);
            service.DeleteCorporative(grid);

            mockSet.Verify(m => m.Remove(It.IsAny<CorporativeTelephone>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod()]
        public void DeleteCorporative_SelectedItem_Founded_ClickNo_NotDelete()
        {
            var list = new List<CorporativeTelephone>
            {
                new CorporativeTelephone { PhoneNumber = "1234567890000", Id = 5 }
            }.AsQueryable();

            DataGrid grid = new DataGrid() { ItemsSource = list, SelectedItem = list.FirstOrDefault() };
            var mockSet = new Mock<DbSet<CorporativeTelephone>>();
            mockSet.As<IQueryable<CorporativeTelephone>>().Setup(m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable<CorporativeTelephone>>().Setup(m => m.Expression).Returns(list.Expression);
            mockSet.As<IQueryable<CorporativeTelephone>>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.As<IQueryable<CorporativeTelephone>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());

            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.CorpPhones).Returns(mockSet.Object);
            mockSet.Setup(m => m.Find(It.IsAny<int>())).Returns(new CorporativeTelephone { PhoneNumber = "1234567890000", Id = 5 });

            DeleteService service = new DeleteService(mockContext.Object);
            service.DeleteCorporative(grid);

            mockSet.Verify(m => m.Remove(It.IsAny<CorporativeTelephone>()), Times.Never());
            mockContext.Verify(m => m.SaveChanges(), Times.Never());
        }

        [TestMethod()]
        public void DeleteCorporative_SelectedItem_NotFounded_NotDelete()
        {
            CorporativeTelephone n = null;
            var list = new List<CorporativeTelephone>
            {
                new CorporativeTelephone { PhoneNumber = "1234567890000", Id = 5 }
            }.AsQueryable();

            DataGrid grid = new DataGrid() { ItemsSource = list, SelectedItem = list.FirstOrDefault() };
            var mockSet = new Mock<DbSet<CorporativeTelephone>>();
            mockSet.As<IQueryable<CorporativeTelephone>>().Setup(m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable<CorporativeTelephone>>().Setup(m => m.Expression).Returns(list.Expression);
            mockSet.As<IQueryable<CorporativeTelephone>>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.As<IQueryable<CorporativeTelephone>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());

            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.CorpPhones).Returns(mockSet.Object);
            mockSet.Setup(m => m.Find(It.IsAny<int>())).Returns(n);

            DeleteService service = new DeleteService(mockContext.Object);
            service.DeleteCorporative(grid);

            mockSet.Verify(m => m.Remove(It.IsAny<CorporativeTelephone>()), Times.Never());
            mockContext.Verify(m => m.SaveChanges(), Times.Never());
        }
    }
}