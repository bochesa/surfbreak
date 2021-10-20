using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Surfbreak.Models.Api.Surfspot
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Dimensions
    {
        //Antal gentagelser for prognose
        [JsonProperty("time")]
        public int Times { get; set; }
    }

    //Timestamp i yyyymmddThhmmssZ Format
    public class Time
    {
        [JsonProperty("data")]
        public IEnumerable<DateTime> Data { get; set; }
    }

    //vindhastighed
    public class WindSpeed
    {
        [JsonProperty("data")]
        public List<double?> Data { get; set; }
    }
    //Vindretning
    public class WindFromDirection
    {
        [JsonProperty("data")]
        public List<double?> Data { get; set; }
    }
    //Regn rate
    public class PrecipitationFlux
    {
        [JsonProperty("data")]
        public List<double?> Data { get; set; }
    }
    //Bølge højde
    public class WaveHeight
    {
        [JsonProperty("data")]
        public List<double?> Data { get; set; }
    }
    //Bølge periode
    public class WavePeriod
    {
        [JsonProperty("data")]
        public List<double?> Data { get; set; }
    }

    //Hav temperatur
    public class SeaTemperature
    {
        [JsonProperty("data")]
        public List<double?> Data { get; set; }
    }

    //Luft temperatur
    public class AirTemperature
    {
        [JsonProperty("data")]
        public List<double?> Data { get; set; }
    }

    //Strøm hastighed
    public class SeaWaterSpeed
    {
        [JsonProperty("data")]
        public List<double?> Data { get; set; }
    }

    //strømretning
    public class SeaWaterToDirection
    {
        [JsonProperty("data")]
        public List<double?> Data { get; set; }
    }

    public class WeatherData
    {
        [JsonProperty("time")]
        public Time Timestamps { get; set; }

        [JsonProperty("wind_speed_at_10m_above_ground_level")]
        public WindSpeed WindSpeed { get; set; }

        [JsonProperty("wind_from_direction_at_10m_above_ground_level")]
        public WindFromDirection WindFromDirection { get; set; }

        [JsonProperty("precipitation_flux")]
        public PrecipitationFlux PrecipitationFlux { get; set; }

        [JsonProperty("sea_surface_wave_significant_height")]
        public WaveHeight WaveHeight { get; set; }

        [JsonProperty("sea_surface_wave_period_at_variance_spectral_density_maximum")]
        public WavePeriod WavePeriod { get; set; }

        [JsonProperty("sea_surface_temperature")]
        public SeaTemperature SeaTemperature { get; set; }

        [JsonProperty("air_temperature_at_2m_above_ground_level")]
        public AirTemperature AirTemperature { get; set; }

        [JsonProperty("surface_sea_water_speed")]
        public SeaWaterSpeed SeaWaterSpeed { get; set; }

        [JsonProperty("surface_sea_water_to_direction")]
        public SeaWaterToDirection SeaWaterToDirection { get; set; }
    }

    public class WeatherConditions
    {
        public int Id { get; set; }
        [JsonProperty("dimensions")]
        public Dimensions Dimensions { get; set; }
        
        [JsonProperty("variables")]
        public WeatherData WeatherData { get; set; }
    }


}
