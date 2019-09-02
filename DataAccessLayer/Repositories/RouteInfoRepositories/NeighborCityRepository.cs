using DreamBusDBLayer;

namespace DataAccessLayer.Repositories
{
    public class NeighborCityRepository : DataBaseGenericRepository<NeighborCity>
    {
        public NeighborCityRepository(DreamBusContext context) : base(context)
        {
        }
    }
}
