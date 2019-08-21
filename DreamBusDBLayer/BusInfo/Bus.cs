namespace DreamBusDBLayer
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Bus")]
    public partial class Bus
    {
        public int Id { get; set; }

        public int BusModelId { get; set; }

        [StringLength(20)]
        public string BusCountryNumber { get; set; }

        public virtual BusModel BusModel { get; set; }
    }
}
