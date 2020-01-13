using CityList.Core.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using CityList.Core.Utilities;

namespace CityList.Core
{
    public class JsonAddressRepository : IAddressRepository
    {
        public async Task<IEnumerable<Address>> GetAddresses()
        {
            string data = await FileUtilities.ReadFileAsync("data.json");

            return JsonConvert.DeserializeObject<List<Address>>(data);
        }
    }
}
