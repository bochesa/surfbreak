using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Surfbreak.Models.Surfspot
{
    public class WeatherCondition
    {
        private DateTime? timeStamp;
        private double? waveHeight;
        private double? wavePeriod;
        private double? windSpeed;
        private double? seaTemperature;

        public int Id { get; set; }

        public DateTime? TimeStamp
        {
            get { return timeStamp; }
            set
            {
                if (value != null)
                {
                    timeStamp = value;
                }
                else
                {
                    timeStamp = new DateTime();
                }
            }
        }
        public double? WaveHeight
        {
            get { return waveHeight; }
            set
            {
                if (value != null)
                {
                    waveHeight = value;
                }
                else
                {
                    waveHeight = 0;
                }
            }
        }
        public double? WavePeriod
        {
            get { return wavePeriod; }
            set
            {
                if (value != null)
                {
                    wavePeriod = value;
                }
                else
                {
                    wavePeriod = 0;
                }
            }
        }
        public double? WindSpeed
        {
            get { return windSpeed; }
            set
            {
                if (value != null)
                {
                    windSpeed = value;
                }
                else
                {
                    windSpeed = 0;
                }
            }
        }
        public double? SeaTemperature 
        { 
            get { return seaTemperature - 273.15; }
            set
            {
                if (value != null)
                {
                    seaTemperature = value;
                }
                else
                {
                    seaTemperature = 0;
                }
            }
        }

    }
}
