using DreamBusDBLayer;

namespace DataAccessLayer.Repositories
{
    public class BusSeatRepository : DataBaseGenericRepository<BusSeat>
    {
        public BusSeatRepository(DreamBusContext context) : base(context)
        {
        }
    }
}
