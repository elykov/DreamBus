namespace DreamBusDBLayer
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BusType")]
    public partial class BusType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BusType()
        {
            BusModels = new HashSet<BusModel>();
        }

        public int Id { get; set; }

        public int PlacesCount { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string BusStruct { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BusModel> BusModels { get; set; }
    }
}
