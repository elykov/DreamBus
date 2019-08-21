using DreamBusDBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CityRepository : DataBaseGenericRepository<City>
    {
        public CityRepository(DreamBusContext context) : base(context)
        {
        }
    }
}
