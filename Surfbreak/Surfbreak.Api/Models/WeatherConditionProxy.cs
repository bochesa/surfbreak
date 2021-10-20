using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Surfbreak.Api.Models
{
    public class WeatherConditionProxy
    {
        private readonly HttpClient client;

        public WeatherConditionProxy(HttpClient client)
        {
            this.client = client;
        }

        public async Task<string> GetWeatherInfo(string lat, string lon, DateTime time)
        {
            //site?lon=10.667&lat=55.457&times=R3/20201106T110000Z/PT1H&units=si&apikey=dDtSc6xH4YLdif09JrlXSpCT0YWHMgo5
            var response = await client.GetAsync($"{client.BaseAddress}site?lon={lon}&lat={lat}&" +
                                                 $"times=R3/{time:yyyyMMdd}T{time:HHmmss}Z/PT1H&" +
                                                 $"units=si&apikey=dDtSc6xH4YLdif09JrlXSpCT0YWHMgo5");
            string result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
