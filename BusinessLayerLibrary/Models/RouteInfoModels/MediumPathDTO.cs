using DreamBusDBLayer;
using System;

namespace BusinessLayerLibrary.Models
{
    public class MediumPathDTO
    {
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор рейса
        /// </summary>
        public int FlightId { get; set; }

        public int PathNum { get; set; }

        public int PathId { get; set; } // id to NeighborCity

        public Flight Flight { get; set; }

        public NeighborCity NeighborCity { get; set; }
    }
}
