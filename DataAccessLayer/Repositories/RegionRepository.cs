using DreamBusDBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class RegionRepository : DataBaseGenericRepository<Region>
    {
        public RegionRepository(DreamBusContext context) : base(context)
        {
        }
    }
}
