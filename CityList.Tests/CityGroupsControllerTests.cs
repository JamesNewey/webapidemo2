using CityList.Core;
using CityList.Core.Types;
using CityList.Web.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace CityList.Tests
{
    [TestClass]
    public class CityGroupsControllerTests
    {
        List<City> testData = new List<City>()
        {
            new City() {
                Name = "London",
                Addresses = new List<Address>() {
                    new Address()
                    {
                        FirstName = "Luke",
                        LastName = "Skywalker",
                        StreetAddress = "35 Skywalker way",
                        City = "London",
                        Country = "England"
                    },
                    new Address()
                    {
                        FirstName = "Leia",
                        LastName = "Organa",
                        StreetAddress = "17 Alderan drive",
                        City = "London",
                        Country = "England"
                    }
                }
            },
            new City() {
                Name = "New York",
                Addresses = new List<Address> () {
                    new Address()
                    {
                        FirstName = "Anakin",
                        LastName = "Skywalker",
                        StreetAddress = "22 Death star st",
                        City = "New York",
                        Country = "America"
                    }
                }
            }
        };

        [TestMethod]
        public void Get_AddressesAvailable_GroupedResultsReturned()
        {
            var mockService = new Mock<ICityAddressService>();
            mockService.Setup(m => m.GetCityAddresses()).ReturnsAsync(() => testData);
            var mockLogger = new Mock<ILogger<CityGroupsController>>();

            var controller = new CityGroupsController(mockLogger.Object, mockService.Object);
            var task = controller.Get();
            var result = task.Result.ToList();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("London", result[0].Name);
            Assert.AreEqual(2, result[0].Addresses.Count());
            Assert.AreEqual("New York", result[1].Name);
            Assert.AreEqual(1, result[1].Addresses.Count());
        }

        [TestMethod]
        public void Get_NoAddressesAvailable_EmptyResultReturned()
        {
            var mockService = new Mock<ICityAddressService>();
            mockService.Setup(m => m.GetCityAddresses()).ReturnsAsync(() => new List<City>());
            var mockLogger = new Mock<ILogger<CityGroupsController>>();

            var controller = new CityGroupsController(mockLogger.Object, mockService.Object);
            var task = controller.Get();
            var result = task.Result.ToList();

            Assert.AreEqual(0, result.Count);
        }
    }
}
