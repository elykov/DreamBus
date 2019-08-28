namespace DreamBusContextTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class City
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public City()
        {
            NeighborCities = new HashSet<NeighborCity>();
            NeighborCities1 = new HashSet<NeighborCity>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public int RegionId { get; set; }

        public virtual Region Region { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NeighborCity> NeighborCities { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NeighborCity> NeighborCities1 { get; set; }
    }
}
