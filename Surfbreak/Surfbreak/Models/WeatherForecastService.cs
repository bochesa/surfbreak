using Newtonsoft.Json;
using Surfbreak.Models.Surfspot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Surfbreak.Models
{
    public class WeatherForecastService
    {
        private readonly WeatherConditionProxy proxy;

        public WeatherForecastService(WeatherConditionProxy proxy)
        {
            this.proxy = proxy;
        }
        public async Task<List<WeatherCondition>> GetWeatherConditionsAsListAsync(Surfspot.Surfspot surfspot)
        {
            var weatherConditionList = new List<WeatherCondition>();

            //https://localhost:44302/weatherdata?lat=55.454&lon=10.669
            string weatherConditionproxy = await proxy.GetWeatherInfo(surfspot.Location.Latitude, surfspot.Location.Longitude);
            WeatherConditions weatherConditions = JsonConvert.DeserializeObject<WeatherConditions>(weatherConditionproxy);
            if (weatherConditions != null)
            {
                for (int i = 0; i < weatherConditions.Dimensions.Times; i++)
                {
                    var weatherCondition = new WeatherCondition()
                    {
                        TimeStamp = weatherConditions.WeatherData.Timestamps.Data.ToArray()[i],
                        WaveHeight = weatherConditions.WeatherData.WaveHeight.Data.ToArray()[i],
                        WavePeriod = weatherConditions.WeatherData.WavePeriod.Data.ToArray()[i],
                        WindSpeed = weatherConditions.WeatherData.WindSpeed.Data.ToArray()[i],
                        SeaTemperature = weatherConditions.WeatherData.SeaTemperature.Data.ToArray()[i]
                    };
                    weatherConditionList.Add(weatherCondition);

                }
                return weatherConditionList;
            }
            else
            {
                return weatherConditionList;
            }
        }
    }
}
