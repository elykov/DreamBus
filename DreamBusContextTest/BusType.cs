namespace DreamBusContextTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BusType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BusType()
        {
            BusModels = new HashSet<BusModel>();
            BusSeats = new HashSet<BusSeat>();
        }

        public int Id { get; set; }

        public int PlacesCount { get; set; }

        public int FloorCount { get; set; }

        public int BusWidth { get; set; }

        public int BusHeight { get; set; }

        public int SeatWidth { get; set; }

        public int SeatHeight { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BusModel> BusModels { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BusSeat> BusSeats { get; set; }
    }
}
