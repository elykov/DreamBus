using DreamBusDBLayer;

namespace DataAccessLayer.Repositories
{
    public class CityRepository : DataBaseGenericRepository<City>
    {
        public CityRepository(DreamBusContext context) : base(context)
        {
        }
    }
}
