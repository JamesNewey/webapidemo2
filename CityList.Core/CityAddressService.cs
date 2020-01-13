using CityList.Core.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Globalization;

namespace CityList.Core
{
    public class CityAddressService : ICityAddressService
    {
        private readonly IAddressRepository repository;

        public CityAddressService(IAddressRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Returns a list of addresses grouped by city.
        /// </summary>
        /// <returns>The list of cities, with corresponding addresses.</returns>
        public async Task<IEnumerable<City>> GetCityAddresses()
        {
            var txtInfo = new CultureInfo("en-GB", false).TextInfo;

            var addresses = await repository.GetAddresses();

            var group = addresses
                .GroupBy(g => txtInfo.ToTitleCase(g.City))
                .Select(g => new City() { Name = g.Key, Addresses = g.ToList() });

            return group;
        }
    }
}
