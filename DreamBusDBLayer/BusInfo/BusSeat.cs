namespace DreamBusDBLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BusSeat
    {
        public int Id { get; set; }

        public int BusTypeId { get; set; }

        public int XCoord { get; set; }

        public int YCoord { get; set; }

        public virtual BusType BusType { get; set; }
    }
}
