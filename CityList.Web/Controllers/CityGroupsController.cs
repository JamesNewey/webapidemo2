using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CityList.Core;
using CityList.Core.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CityList.Web.Models;

namespace CityList.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityGroupsController : ControllerBase
    {
        ICityAddressService cityAddressService;

        private readonly ILogger<CityGroupsController> _logger;

        public CityGroupsController(ILogger<CityGroupsController> logger, ICityAddressService service)
        {
            _logger = logger;
            cityAddressService = service;
        }

        [HttpGet]
        public async Task<IEnumerable<City>> Get()
        {
            var cities = await cityAddressService.GetCityAddresses();

            return cities;
        }
    }
}
