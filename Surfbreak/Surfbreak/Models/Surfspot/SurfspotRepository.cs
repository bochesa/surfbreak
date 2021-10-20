using Microsoft.EntityFrameworkCore;
using Surfbreak.Models.Surfspot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Surfbreak.Models;
using Newtonsoft.Json;

namespace Surfbreak
{
    public class SurfspotRepository
    {

        private readonly SurfspotDataContext _db;
        private readonly WeatherConditionProxy proxy;

        public SurfspotRepository(SurfspotDataContext db, WeatherConditionProxy proxy)
        {
            _db = db;
            this.proxy = proxy;
        }
        public Surfspot GetSurfspotById(int id)
        {
            var surfspot = _db.Surfspots.FirstOrDefault(x => x.Id == id);
            //surfspot.WeatherConditions = new List<WeatherCondition>();
            if(surfspot != null)
            {
                surfspot.Location = _db.Locations.FirstOrDefault(x => x.Id == surfspot.LocationId);
                foreach (var item in _db.Comments)
                {
                    if (item.SurfspotId == surfspot.Id)
                    {
                        surfspot.Comments.ToList().Add(item);
                    }
                }
            }
            return surfspot;
            ////https://localhost:44302/weatherdata?lat=55.454&lon=10.669
            //string weatherConditionproxy = await proxy.GetWeatherInfo(surfspot.Location.Latitude, surfspot.Location.Longitude);
            //WeatherConditions weatherConditions = JsonConvert.DeserializeObject<WeatherConditions>(weatherConditionproxy);
            //if (weatherConditions != null)
            //{
            //    for (int i = 0; i < weatherConditions.Dimensions.Times; i++)
            //    {
            //        var weatherCondition = new WeatherCondition()
            //        {
            //            TimeStamp = weatherConditions.WeatherData.Timestamps.Data.ToArray()[i],
            //            WaveHeight = weatherConditions.WeatherData.WaveHeight.Data.ToArray()[i],
            //            WavePeriod = weatherConditions.WeatherData.WavePeriod.Data.ToArray()[i],
            //            WindSpeed = weatherConditions.WeatherData.WindSpeed.Data.ToArray()[i],
            //            SeaTemperature = weatherConditions.WeatherData.SeaTemperature.Data.ToArray()[i]
            //        };
            //        surfspot.WeatherConditions.Add(weatherCondition);

            //    }
            //    return surfspot;
            //}
            //else
            //{
            //    return surfspot;
            //}
        }
        public void UpdateSurfspot(Surfspot surfspot)
        {
            _db.Update(surfspot);
        }
        public void UpdateRowVersion(Surfspot surfspot, byte[] rowVersion)
        {
            _db.Entry(surfspot).Property("RowVersion").OriginalValue = rowVersion;
        }
        public IEnumerable<Comment> GetAllComments()
        {
            return _db.Comments;
        }
        public void AddComment(Comment comment)
        {
            _db.Add(comment);
        }
        public int SaveChanges()
        {
            return _db.SaveChanges();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
