using CityList.Core;
using CityList.Core.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace CityList.Tests
{
    [TestClass]
    public class CityAddressServiceTests
    {
        List<Address> testData = new List<Address>()
        {
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
                City = "london",
                Country = "England"
            },
            new Address()
            {
                FirstName = "Anakin",
                LastName = "Skywalker",
                StreetAddress = "22 Death star st",
                City = "New York",
                Country = "America"
            }
        };

        [TestMethod]
        public void GetCityAddresses_AddressesAvailable_GroupedResultsReturned()
        {
            var mockRepository = new Mock<IAddressRepository>();
            mockRepository.Setup(m => m.GetAddresses()).ReturnsAsync(() => testData);

            var service = new CityAddressService(mockRepository.Object);
            var task = service.GetCityAddresses();
            var result = task.Result.ToList();

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetCityAddresses_NoAddressesAvailable_EmptyResultReturned()
        {
            var mockRepository = new Mock<IAddressRepository>();
            mockRepository.Setup(m => m.GetAddresses()).ReturnsAsync(() => new List<Address>());

            var service = new CityAddressService(mockRepository.Object);
            var task = service.GetCityAddresses();
            var result = task.Result.ToList();

            Assert.AreEqual(0, result.Count);
        }
    }
}
