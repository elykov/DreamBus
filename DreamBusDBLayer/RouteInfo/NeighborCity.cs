namespace DreamBusDBLayer
{
    using System.Collections.Generic;

    public partial class NeighborCity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NeighborCity()
        {
            MediumPathes = new HashSet<MediumPathe>();
        }

        public int Id { get; set; }

        public int CityId { get; set; }

        public int NeighborId { get; set; }

        public int MinutesInPath { get; set; }

        public virtual City City { get; set; }

        public virtual City Neighbor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MediumPathe> MediumPathes { get; set; }
    }
}
