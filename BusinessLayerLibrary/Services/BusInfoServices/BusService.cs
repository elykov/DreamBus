using AutoMapper;
using DataAccessLayer;
using DreamBusDBLayer;

namespace BusinessLayerLibrary.Services.BusInfoServices
{
    public class BusService : AGenericService<Bus, Bus>
    {
        public BusService(IGenericRepository<Bus> repository) : base(repository)
        {
        }

        protected override IMapper GetMapper()
        {
            return new MapperConfiguration(cfg => { }).CreateMapper();
        }
    }
}
