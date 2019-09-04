using AutoMapper;
using DataAccessLayer;
using DreamBusDBLayer;

namespace BusinessLayerLibrary.Services.BusInfoServices
{
    public class BusTypeService : AGenericService<BusType, BusType>
    {
        public BusTypeService(IGenericRepository<BusType> repository) : base(repository)
        {
        }

        protected override IMapper GetMapper()
        {
            return new MapperConfiguration(cfg => {}).CreateMapper();
        }
    }
}
