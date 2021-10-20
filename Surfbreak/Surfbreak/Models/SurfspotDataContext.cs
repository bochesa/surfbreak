using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Surfbreak.Models.Surfspot;

namespace Surfbreak
{
    public class SurfspotDataContext : DbContext
    {
        public SurfspotDataContext(DbContextOptions<SurfspotDataContext> options)
            : base(options)
        {
        }

        public DbSet<Surfspot> Surfspots {get;set;}
        public DbSet<Comment> Comments { get; set; }
        public DbSet<WeatherCondition> WeatherConditions { get; set; }
        public DbSet<Location> Locations { get; set; }

    }
}
