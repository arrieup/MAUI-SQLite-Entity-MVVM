using MAUI_Core.Models;
using MAUI_Core.ViewModels;
using MAUI_Core.Services;
using Moq;

namespace MAUI_Tests.ViewModels
{
    [TestClass()]
    public class ListViewModelTests
    {

        private TemplateListViewModel vm;

        public ListViewModelTests()
        {
            var mockDBService = new Mock<IDatabaseService<Template>>();
            var mockNAVService = new Mock<INavigationService<Template>>();
            vm = new TemplateListViewModel(mockDBService.Object, mockNAVService.Object);
        }

        [TestMethod()]
        [DataRow("abcde", "redety",2)]
        [DataRow("abcde", "rledety",2)]
        [DataRow("abcde", "rcdety",3)]
        public void LongestCommonSubstringLengthTest(string a, string b, int expected)
        {
            Assert.AreEqual(expected, ListViewModel<Template>.LongestCommonSubstringLength(a, b));
        }

        // TODO: Add more tests for the ListViewModel class
    }
}