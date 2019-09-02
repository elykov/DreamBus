using DreamBusDBLayer;

namespace DataAccessLayer.Repositories
{
    public class RegionRepository : DataBaseGenericRepository<Region>
    {
        public RegionRepository(DreamBusContext context) : base(context)
        {
        }
    }
}
