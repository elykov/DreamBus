namespace DreamBusDBLayer
{
    public partial class BusSeat
    {
        public int Id { get; set; }

        public int BusTypeId { get; set; }

        public int XCoord { get; set; }

        public int YCoord { get; set; }

        public byte SeatNumber { get; set; }

        public virtual BusType BusType { get; set; }
    }
}
