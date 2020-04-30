using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.Models;
using Web.Security;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly ILogger<RegionController> _logger;
        private readonly IDataProtector _protector;

        private IEnumerable<Region> Regions => GetRegions();

        #region Constructor

        public RegionController(ILogger<RegionController> logger, IDataProtectionProvider dataProtectionProvider, DataProtectionPurposeStrings dataProtectionPurposeStrings)
        {
            _logger = logger;
            _protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.RegionIdRouteValue);
        }

        #endregion

        [HttpGet]
        public IEnumerable<Region> Get()
        {
            return Regions;
        }

        [HttpGet]
        [Route("{id}")]
        public Region GetRegion(string id) 
        {
            int decryptedId = Convert.ToInt32(_protector.Unprotect(id));

            return Regions.FirstOrDefault(x => x.Id == decryptedId);
        }

        #region Private Method

        private IEnumerable<Region> GetRegions()
        {
            string[] regionNames = new[] {
                "Taipei", "Taichung", "Chiayi", "Kaohsiung", "Taitung"
            };

            return Enumerable.Range(0, regionNames.Length).Select(index => new Region {
                EncryptedId = _protector.Protect(index.ToString()),
                Id = index,
                Name = regionNames[index],
                WeatherForecast = GetWeatherForecast()
            }).ToArray();
        }

        private WeatherForecast GetWeatherForecast()
        {
            string[] summaries = new[] {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            var rng = new Random();

            return new WeatherForecast() {
                Date = DateTime.Now.AddDays(1),
                TemperatureC = rng.Next(-20, 55),
                Summary = summaries[rng.Next(summaries.Length)]
            };
        }

        #endregion
    }
}
