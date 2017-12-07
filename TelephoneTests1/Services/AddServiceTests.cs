using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telephone.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephone.Models;
using Moq;
using System.Data.Entity;

namespace Telephone.Services.Tests
{
    [TestClass()]
    public class AddServiceTests
    {
        [TestMethod()]
        public void IsDublicate_ExistNumberInFirstTable_ReturnTrue()
        {
            var data1 = new List<CorporativeTelephone>
            {
                new CorporativeTelephone { PhoneNumber = "1234567890000" },
                new CorporativeTelephone { PhoneNumber = "1234567890001" }
            }.AsQueryable();

            var data2 = new List<PersonalTelephone>
            {
                new PersonalTelephone { PhoneNumber = "1234567890000" },
                new PersonalTelephone { PhoneNumber = "1234567890001" }
            }.AsQueryable();

            var mockSetC = new Mock<DbSet<CorporativeTelephone>>();
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.Provider).Returns(data1.Provider);
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.Expression).Returns(data1.Expression);
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.ElementType).Returns(data1.ElementType);
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.GetEnumerator()).Returns(data1.GetEnumerator());

            var mockSetP = new Mock<DbSet<PersonalTelephone>>();
            mockSetP.As<IQueryable<PersonalTelephone>>().Setup(m => m.Provider).Returns(data2.Provider);
            mockSetP.As<IQueryable<PersonalTelephone>>().Setup(m => m.Expression).Returns(data2.Expression);
            mockSetP.As<IQueryable<PersonalTelephone>>().Setup(m => m.ElementType).Returns(data2.ElementType);
            mockSetP.As<IQueryable<PersonalTelephone>>().Setup(m => m.GetEnumerator()).Returns(data2.GetEnumerator());

            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.CorpPhones).Returns(mockSetC.Object);
            mockContext.Setup(m => m.PersPhone).Returns(mockSetP.Object);
            AddService service = new AddService(mockContext.Object);
            bool result = service.IsDublicate("1234567890000");

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsDublicate_NotExistNumber_ReturnFalse()
        {
            var data1 = new List<CorporativeTelephone>
            {
                new CorporativeTelephone { PhoneNumber = "1234567890000" },
                new CorporativeTelephone { PhoneNumber = "1234567890001" }
            }.AsQueryable();

            var data2 = new List<PersonalTelephone>
            {
                new PersonalTelephone { PhoneNumber = "1234567890000" },
                new PersonalTelephone { PhoneNumber = "1234567890001" }
            }.AsQueryable();

            var mockSetC = new Mock<DbSet<CorporativeTelephone>>();
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.Provider).Returns(data1.Provider);
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.Expression).Returns(data1.Expression);
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.ElementType).Returns(data1.ElementType);
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.GetEnumerator()).Returns(data1.GetEnumerator());

            var mockSetP = new Mock<DbSet<PersonalTelephone>>();
            mockSetP.As<IQueryable<PersonalTelephone>>().Setup(m => m.Provider).Returns(data2.Provider);
            mockSetP.As<IQueryable<PersonalTelephone>>().Setup(m => m.Expression).Returns(data2.Expression);
            mockSetP.As<IQueryable<PersonalTelephone>>().Setup(m => m.ElementType).Returns(data2.ElementType);
            mockSetP.As<IQueryable<PersonalTelephone>>().Setup(m => m.GetEnumerator()).Returns(data2.GetEnumerator());

            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.CorpPhones).Returns(mockSetC.Object);
            mockContext.Setup(m => m.PersPhone).Returns(mockSetP.Object);

            AddService service = new AddService(mockContext.Object);
            bool result = service.IsDublicate("1234567890002");

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void IsDublicate_ExistNumberInSecondTable_ReturnTrue()
        {
            var data1 = new List<CorporativeTelephone>
            {
                new CorporativeTelephone { PhoneNumber = "1234567890000" },
                new CorporativeTelephone { PhoneNumber = "1234567890001" }
            }.AsQueryable();

            var data2 = new List<PersonalTelephone>
            {
                new PersonalTelephone { PhoneNumber = "1234567890000" },
                new PersonalTelephone { PhoneNumber = "1234567890001" }
            }.AsQueryable();

            var mockSetC = new Mock<DbSet<CorporativeTelephone>>();
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.Provider).Returns(data1.Provider);
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.Expression).Returns(data1.Expression);
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.ElementType).Returns(data1.ElementType);
            mockSetC.As<IQueryable<CorporativeTelephone>>().Setup(m => m.GetEnumerator()).Returns(data1.GetEnumerator());

            var mockSetP = new Mock<DbSet<PersonalTelephone>>();
            mockSetP.As<IQueryable<PersonalTelephone>>().Setup(m => m.Provider).Returns(data2.Provider);
            mockSetP.As<IQueryable<PersonalTelephone>>().Setup(m => m.Expression).Returns(data2.Expression);
            mockSetP.As<IQueryable<PersonalTelephone>>().Setup(m => m.ElementType).Returns(data2.ElementType);
            mockSetP.As<IQueryable<PersonalTelephone>>().Setup(m => m.GetEnumerator()).Returns(data2.GetEnumerator());

            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.CorpPhones).Returns(mockSetC.Object);
            mockContext.Setup(m => m.PersPhone).Returns(mockSetP.Object);


            AddService service = new AddService(mockContext.Object);
            bool result = service.IsDublicate("123456789000");

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void AddPhone_SelectedNull_NotDublicate_Valid()
        {
            var mockSet = new Mock<DbSet<PersonalTelephone>>();
            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.PersPhone).Returns(mockSet.Object);           

            var mockService = new Mock<AddService>(mockContext.Object);
            mockService.Setup(m => m.PersonalAdd(It.IsAny<Data>())).Returns(new PersonalTelephone());
            Data data = new Data
            {
                Number = "1234567889012",
                Address = "address",
                Name = "name",
                Surname = "surname",
                Patronymic = "patronymic"
            };
            
            mockService.Object.AddPhone(0, false, data, true);
            mockService.Verify(m => m.PersonalAdd(It.IsAny<Data>()), Times.Once());
        }

        [TestMethod()]
        public void AddPhone_SelectedNull_Dublicate_Valid()
        {
            var mockSet = new Mock<DbSet<PersonalTelephone>>();
            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.PersPhone).Returns(mockSet.Object);

            var mockService = new Mock<AddService>(mockContext.Object);
            mockService.Setup(m => m.PersonalAdd(It.IsAny<Data>())).Returns(new PersonalTelephone());
            Data data = new Data
            {
                Number = "1234567889012",
                Address = "address",
                Name = "name",
                Surname = "surname",
                Patronymic = "patronymic"
            };

            mockService.Object.AddPhone(0, true, data, true);
            mockService.Verify(m => m.PersonalAdd(It.IsAny<Data>()), Times.Never());
        }

        [TestMethod()]
        public void AddPhone_SelectedNull_Dublicate_Invalid()
        {
            var mockSet = new Mock<DbSet<PersonalTelephone>>();
            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.PersPhone).Returns(mockSet.Object);

            var mockService = new Mock<AddService>(mockContext.Object);
            mockService.Setup(m => m.PersonalAdd(It.IsAny<Data>())).Returns(new PersonalTelephone());
            Data data = new Data
            {
                Number = "1234567889012",
                Address = "address",
                Name = "name",
                Surname = "surname",
                Patronymic = "patronymic"
            };

            mockService.Object.AddPhone(0, true, data, false);
            mockService.Verify(m => m.PersonalAdd(It.IsAny<Data>()), Times.Never());
        }

        [TestMethod()]
        public void AddPhone_SelectedNull_NotDublicate_Invalid()
        {
            var mockSet = new Mock<DbSet<PersonalTelephone>>();
            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.PersPhone).Returns(mockSet.Object);

            var mockService = new Mock<AddService>(mockContext.Object);
            mockService.Setup(m => m.PersonalAdd(It.IsAny<Data>())).Returns(new PersonalTelephone());
            Data data = new Data
            {
                Number = "1234567889012",
                Address = "address",
                Name = "name",
                Surname = "surname",
                Patronymic = "patronymic"
            };

            mockService.Object.AddPhone(0, false, data, false);
            mockService.Verify(m => m.PersonalAdd(It.IsAny<Data>()), Times.Never());
        }

        [TestMethod()]
        public void AddPhone_SelectedOne_NotDublicate_Valid()
        {
            var mockSet = new Mock<DbSet<CorporativeTelephone>>();
            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.CorpPhones).Returns(mockSet.Object);

            var mockService = new Mock<AddService>(mockContext.Object);
            mockService.Setup(m => m.CorpAdd(It.IsAny<Data>())).Returns(new CorporativeTelephone());
            Data data = new Data
            {
                Number = "1234567889012",
                Address = "address",
                Occupation = "IT",
                Company = "company"
            };

            mockService.Object.AddPhone(1, false, data, true);
            mockService.Verify(m => m.CorpAdd(It.IsAny<Data>()), Times.Once());
        }

        [TestMethod()]
        public void AddPhone_SelectedOne_Dublicate_Valid()
        {
            var mockSet = new Mock<DbSet<CorporativeTelephone>>();
            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.CorpPhones).Returns(mockSet.Object);

            var mockService = new Mock<AddService>(mockContext.Object);
            mockService.Setup(m => m.CorpAdd(It.IsAny<Data>())).Returns(new CorporativeTelephone());
            Data data = new Data
            {
                Number = "1234567889012",
                Address = "address",
                Occupation = "IT",
                Company = "company"
            };

            mockService.Object.AddPhone(1, true, data, true);
            mockService.Verify(m => m.CorpAdd(It.IsAny<Data>()), Times.Never());
        }

        [TestMethod()]
        public void AddPhone_SelectedOne_Dublicate_Invalid()
        {
            var mockSet = new Mock<DbSet<CorporativeTelephone>>();
            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.CorpPhones).Returns(mockSet.Object);

            var mockService = new Mock<AddService>(mockContext.Object);
            mockService.Setup(m => m.CorpAdd(It.IsAny<Data>())).Returns(new CorporativeTelephone());
            Data data = new Data
            {
                Number = "1234567889012",
                Address = "address",
                Occupation = "IT",
                Company = "company"
            };

            mockService.Object.AddPhone(1, true, data, false);
            mockService.Verify(m => m.CorpAdd(It.IsAny<Data>()), Times.Never());
        }

        [TestMethod()]
        public void AddPhone_SelectedOne_NotDublicate_Invalid()
        {
            var mockSet = new Mock<DbSet<CorporativeTelephone>>();
            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.CorpPhones).Returns(mockSet.Object);

            var mockService = new Mock<AddService>(mockContext.Object);
            mockService.Setup(m => m.CorpAdd(It.IsAny<Data>())).Returns(new CorporativeTelephone());
            Data data = new Data
            {
                Number = "1234567889012",
                Address = "address",
                Occupation = "IT",
                Company = "company"
            };

            mockService.Object.AddPhone(1, false, data, false);
            mockService.Verify(m => m.CorpAdd(It.IsAny<Data>()), Times.Never());
        }

        [TestMethod()]
        public void AddPhone_NotSelected()
        {
            var mockSetCorp = new Mock<DbSet<CorporativeTelephone>>();
            var mockSetPers = new Mock<DbSet<PersonalTelephone>>();
            var mockContext = new Mock<PhoneContext>();
            mockContext.Setup(m => m.CorpPhones).Returns(mockSetCorp.Object);
            mockContext.Setup(m => m.PersPhone).Returns(mockSetPers.Object);
            var mockService = new Mock<AddService>(mockContext.Object);
            mockService.Setup(m => m.CorpAdd(It.IsAny<Data>())).Returns(new CorporativeTelephone());
            mockService.Setup(m => m.PersonalAdd(It.IsAny<Data>())).Returns(new PersonalTelephone());
            Data data = new Data
            {
                Number = "1234567889012",
                Address = "address",
                Occupation = "IT",
                Company = "company",
                Name = "name",
                Surname = "surname",
                Patronymic = "patronymic"
            };   
            
            mockService.Object.AddPhone(-1, false, data, true);
            mockService.Verify(m => m.PersonalAdd(It.IsAny<Data>()), Times.Never());
            mockService.Verify(m => m.CorpAdd(It.IsAny<Data>()), Times.Never());
        }

        [TestMethod()]
        public void CorpAdd_AddPhone()
        {
            var mockSetC = new Mock<DbSet<CorporativeTelephone>>();
            var mockContext = new Mock<PhoneContext>();

            mockContext.Setup(m => m.CorpPhones).Returns(mockSetC.Object);

            Data data = new Data
            {
                Number = "1234567889012",
                Address = "address",
                Occupation = "IT",
                Company = "company",
                Name = "name",
                Surname = "surname",
                Patronymic = "patronymic"
            };

            var service = new AddService(mockContext.Object);
            var result = service.CorpAdd(data);

            mockSetC.Verify(m => m.Add(It.IsAny<CorporativeTelephone>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());

            Assert.IsNotNull(result);
        }



        [TestMethod()]
        public void PersonalAdd_AddPhone()
        {
            var mockSet = new Mock<DbSet<PersonalTelephone>>();
            var mockContext = new Mock<PhoneContext>();


            mockContext.Setup(m => m.PersPhone).Returns(mockSet.Object);

            Data data = new Data
            {
                Number = "1234567889012",
                Address = "address",
                Occupation = "IT",
                Company = "company",
                Name = "name",
                Surname = "surname",
                Patronymic = "patronymic"
            };

            var service = new AddService(mockContext.Object);
            var result = service.PersonalAdd(data);

            mockSet.Verify(m => m.Add(It.IsAny<PersonalTelephone>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());

            Assert.IsNotNull(result);
        }
    }
}