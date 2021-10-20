using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Surfbreak.Models.Surfspot
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Dimensions
    {
        //Antal gentagelser for prognose
        [JsonProperty("times")]
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
        [JsonProperty("timestamps")]
        public Time Timestamps { get; set; }

        [JsonProperty("windSpeed")]
        public WindSpeed WindSpeed { get; set; }

        [JsonProperty("windFromDirection")]
        public WindFromDirection WindFromDirection { get; set; }

        [JsonProperty("precipitationFlux")]
        public PrecipitationFlux PrecipitationFlux { get; set; }

        [JsonProperty("waveHeight")]
        public WaveHeight WaveHeight { get; set; }

        [JsonProperty("wavePeriod")]
        public WavePeriod WavePeriod { get; set; }

        [JsonProperty("seaTemperature")]
        public SeaTemperature SeaTemperature { get; set; }

        [JsonProperty("airTemperature")]
        public AirTemperature AirTemperature { get; set; }

        [JsonProperty("seaWaterSpeed")]
        public SeaWaterSpeed SeaWaterSpeed { get; set; }

        [JsonProperty("seaWaterToDirection")]
        public SeaWaterToDirection SeaWaterToDirection { get; set; }
    }

    public class WeatherConditions
    {
        public int Id { get; set; }
        [JsonProperty("dimensions")]
        public Dimensions Dimensions { get; set; }
        
        [JsonProperty("weatherData")]
        public WeatherData WeatherData { get; set; }
    }


}
