using DreamBusDBLayer;

namespace DataAccessLayer.Repositories
{
    public class BusRepository : DataBaseGenericRepository<Bus>
    {
        public BusRepository(DreamBusContext context) : base(context)
        {
        }
    }
}
