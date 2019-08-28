namespace DreamBusDBLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MediumPath
    {
        public int Id { get; set; }

        public int FlightId { get; set; }

        public int PathNum { get; set; }

        public int PathId { get; set; }

        public TimeSpan DepartureTime { get; set; }

        public virtual Flight Flight { get; set; }

        public virtual NeighborCity NeighborCity { get; set; }
    }
}
