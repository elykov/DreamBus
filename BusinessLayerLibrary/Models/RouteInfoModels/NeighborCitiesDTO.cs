using DreamBusDBLayer;

namespace BusinessLayerLibrary.Models
{
    public class NeighborCitiesDTO
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int NeighborId { get; set; }

        public int MinutesInPath { get; set; }

        public virtual City City { get; set; }
        public virtual City Neighbor { get; set; }
    }
}
