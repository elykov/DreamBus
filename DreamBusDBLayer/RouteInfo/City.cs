namespace DreamBusDBLayer
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class City
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public City()
        //{
        //    NeighborCities_Cities = new HashSet<NeighborCity>();
        //    NeighborCities_Neighbors = new HashSet<NeighborCity>();
        //}
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<NeighborCity> NeighborCities_Cities { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<NeighborCity> NeighborCities_Neighbors { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public int RegionId { get; set; }

        public virtual Region Region { get; set; }

    }
}
