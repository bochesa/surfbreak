using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Surfbreak.Models.Surfspot
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int SurfspotId { get; set; }

    }
}
