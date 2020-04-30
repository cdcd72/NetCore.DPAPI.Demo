using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.Models;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly ILogger<RegionController> _logger;

        private IEnumerable<Region> Regions => GetRegions();

        #region Constructor

        public RegionController(ILogger<RegionController> logger)
        {
            this._logger = logger;
        }

        #endregion

        [HttpGet]
        public IEnumerable<Region> Get()
        {
            return Regions;
        }

        [HttpGet]
        [Route("{id}")]
        public Region GetRegion(int? id) 
        {
            return Regions.FirstOrDefault(x => x.Id == id.Value);
        }

        #region Private Method

        private IEnumerable<Region> GetRegions()
        {
            string[] regionNames = new[] {
                "Taipei", "Taichung", "Chiayi", "Kaohsiung", "Taitung"
            };

            return Enumerable.Range(0, regionNames.Length).Select(index => new Region {
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
