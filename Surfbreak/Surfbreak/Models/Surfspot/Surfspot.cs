using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Surfbreak.Models.Surfspot
{
    public class Surfspot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool IsSecret { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public List<WeatherCondition> WeatherConditions { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
