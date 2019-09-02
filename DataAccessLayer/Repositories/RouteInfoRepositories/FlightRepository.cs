using DreamBusDBLayer;

namespace DataAccessLayer.Repositories
{
    public class FlightRepository : DataBaseGenericRepository<Flight>
    {
        public FlightRepository(DreamBusContext context) : base(context)
        {
        }
    }
}
