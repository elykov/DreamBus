namespace DreamBusDBLayer
{
    using System.ComponentModel.DataAnnotations;

    public partial class City
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public int RegionId { get; set; }

        public virtual Region Region { get; set; }
    }
}
