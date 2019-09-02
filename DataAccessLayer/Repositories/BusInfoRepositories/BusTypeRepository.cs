using DreamBusDBLayer;

namespace DataAccessLayer.Repositories
{
    public class BusTypeRepository : DataBaseGenericRepository<BusType>
    {
        public BusTypeRepository(DreamBusContext context) : base(context)
        {
        }
    }
}
