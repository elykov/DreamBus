namespace DreamBusDBLayer
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class BusModel
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public BusModel()
        //{
        //    Buses = new HashSet<Bus>();
        //}
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Bus> Buses { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Brand { get; set; }

        public byte ComfortFactor { get; set; }

        public int BusTypeId { get; set; }

        public virtual BusType BusType { get; set; }
    }
}
