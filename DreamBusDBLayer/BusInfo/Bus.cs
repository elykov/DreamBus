namespace DreamBusDBLayer
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Bus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bus()
        {
            Flights = new HashSet<Flight>();
        }

        public int Id { get; set; }

        public int BusModelId { get; set; }

        [StringLength(20)]
        public string BusCountryNumber { get; set; }

        public virtual BusModel BusModel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flight> Flights { get; set; }

        public void Qwe()
        {
            //BusModel.BusType.
        }
    }
}
