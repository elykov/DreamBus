namespace DreamBusDBLayer
{
    public partial class MediumPath
    {
        public int Id { get; set; }

        public int FlightId { get; set; }

        public int PathNum { get; set; }

        public int PathId { get; set; }

        public virtual Flight Flight { get; set; }

        public virtual NeighborCity NeighborCity { get; set; }
    }
}
