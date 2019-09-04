using AutoMapper;
using DataAccessLayer;
using DreamBusDBLayer;

namespace BusinessLayerLibrary.Services.BusInfoServices
{
    public class BusSeatService : AGenericService<BusSeat, BusSeat>
    {
        public BusSeatService(IGenericRepository<BusSeat> repository) : base(repository)
        {
        }

        protected override IMapper GetMapper()
        {
            return new MapperConfiguration(cfg => {}).CreateMapper();
        }
    }
}
