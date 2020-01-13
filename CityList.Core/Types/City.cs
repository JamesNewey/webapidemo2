using System;
using System.Collections.Generic;
using System.Text;

namespace CityList.Core.Types
{
    public class City
    {
        public string Name { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}
