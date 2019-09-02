using DreamBusDBLayer;

namespace DataAccessLayer.Repositories
{
    public class BusModelRepository : DataBaseGenericRepository<BusModel>
    {
        public BusModelRepository(DreamBusContext context) : base(context)
        {
        }
    }
}
