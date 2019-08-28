namespace DreamBusContextTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BusModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BusModel()
        {
            Buses = new HashSet<Bus>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Brand { get; set; }

        public int BusTypeId { get; set; }

        public byte ComfortFactor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bus> Buses { get; set; }

        public virtual BusType BusType { get; set; }
    }
}
