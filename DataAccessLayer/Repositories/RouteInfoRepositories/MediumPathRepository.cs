using DreamBusDBLayer;

namespace DataAccessLayer.Repositories
{
    public class MediumPathRepository : DataBaseGenericRepository<MediumPathe>
    {
        public MediumPathRepository(DreamBusContext context) : base(context)
        {
        }
    }
}
