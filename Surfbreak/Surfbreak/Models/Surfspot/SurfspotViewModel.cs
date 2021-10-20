using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Surfbreak.Models.Surfspot
{
    public class SurfspotViewModel
    {
        public Surfspot Surfspot { get; set; }
        public Comment Comment { get; set; }
        public WeatherCondition WeatherCondition { get; set; }
    }
}
