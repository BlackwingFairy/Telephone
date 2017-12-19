using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telephone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephone.Models;
using Moq;
using Telephone.Services;
using System.Windows.Controls;

namespace Telephone.Tests
{
    [TestClass()]
    public class SearchPageTests
    {
        [TestMethod()]
        public void Search_Checked_Valid_FillPersGrid()
        {
            var mockService = new Mock<SearchService>();
            SearchPage page = new SearchPage(mockService.Object);
            page.Search("text", 0, true, true);
            mockService.Verify(m => m.SearchPersonal(It.IsAny<string>(), It.IsAny<int>()), Times.Once());
            mockService.Verify(m => m.FillGrid(It.IsAny<DataGrid>(), It.IsAny<DataGrid>(),
                It.IsAny<Label>(), It.IsAny<Label>(), It.IsAny<IEnumerable<Phone>>()), Times.Once());
        }

        [TestMethod()]
        public void Search_NotChecked_Valid_FillCorpGrid()
        {
            var mockService = new Mock<SearchService>();
            SearchPage page = new SearchPage(mockService.Object);
            page.Search("text", 0, false, true);
            mockService.Verify(m => m.SearchCorporative(It.IsAny<string>(), It.IsAny<int>()), Times.Once());
            mockService.Verify(m => m.FillGrid(It.IsAny<DataGrid>(), It.IsAny<DataGrid>(),
                It.IsAny<Label>(), It.IsAny<Label>(), It.IsAny<IEnumerable<Phone>>()), Times.Once());
        }

        [TestMethod()]
        public void Search_Checked_NotValid_NoAction()
        {
            var mockService = new Mock<SearchService>();
            SearchPage page = new SearchPage(mockService.Object);
            page.Search("text", 0, true, false);
            mockService.Verify(m => m.SearchPersonal(It.IsAny<string>(), It.IsAny<int>()), Times.Never());
            mockService.Verify(m => m.FillGrid(It.IsAny<DataGrid>(), It.IsAny<DataGrid>(),
                It.IsAny<Label>(), It.IsAny<Label>(), It.IsAny<IEnumerable<Phone>>()), Times.Never());
        }

        [TestMethod()]
        public void Search_NotChecked_NotValid_NoAction()
        {
            var mockService = new Mock<SearchService>();
            SearchPage page = new SearchPage(mockService.Object);
            page.Search("text", 0, false, false);
            mockService.Verify(m => m.SearchCorporative(It.IsAny<string>(), It.IsAny<int>()), Times.Never());
            mockService.Verify(m => m.FillGrid(It.IsAny<DataGrid>(), It.IsAny<DataGrid>(),
                It.IsAny<Label>(), It.IsAny<Label>(), It.IsAny<IEnumerable<Phone>>()), Times.Never());
        }
    }
}