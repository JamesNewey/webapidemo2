using CityList.Core.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CityList.Core
{
    public interface ICityAddressService
    {
        Task<IEnumerable<City>> GetCityAddresses();
    }
}
