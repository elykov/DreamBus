using DreamBusDBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerLibrary.Models
{
    public class NeighborCitiesDTO
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int NeighborId { get; set; }

        public int? MinutesInPath { get; set; }
        public double? Distance { get; set; }

        public City City { get; set; }
        public City Neighbor { get; set; }
    }
}
