using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Surfbreak.Api.Models;
using Surfbreak.Models.Api.Surfspot;

namespace Surfbreak.Api.Controllers
{
    [Produces("application/json", "application/xml")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class WeatherDataController : ControllerBase
    {
        private readonly WeatherConditionProxy proxy;

        public WeatherDataController(WeatherConditionProxy proxy)
        {
            this.proxy = proxy;
        }
        //This api get data from other Api via Proxy
        [HttpGet]
        public async Task<IActionResult> WeatherData(string lat, string lon)
        {
            string weatherConditionproxy = await proxy.GetWeatherInfo(lat, lon, DateTime.Now);
            //This Deserialization is redundant
            WeatherConditions weatherConditions = JsonConvert.DeserializeObject<WeatherConditions>(weatherConditionproxy);
            return Ok(weatherConditions);
        }

        //this API post data to database from NZ API
        //[HttpPost]
        //public IActionResult WeatherData(int x)
        //{
        //    return Ok();
        //}

        //[HttpPut]
        //public IActionResult WeatherData(double x)
        //{
        //    return Ok();
        //}
        //[HttpDelete]
        //public IActionResult WeatherData(long x)
        //{
        //    return Ok();
        //}

    }
}
