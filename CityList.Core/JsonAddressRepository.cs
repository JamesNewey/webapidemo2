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
    /// <summary>
    /// Repository for addresses stored in JSON.
    /// </summary>
    public class JsonAddressRepository : IAddressRepository
    {
        private const string filePath = "data.json";

        /// <summary>
        /// Get the addresses from the JSON file.
        /// </summary>
        /// <returns>The list of address objects.</returns>
        public async Task<IEnumerable<Address>> GetAddresses()
        {
            string data = await FileUtilities.ReadFileAsync(filePath);

            return JsonConvert.DeserializeObject<List<Address>>(data);
        }
    }
}
