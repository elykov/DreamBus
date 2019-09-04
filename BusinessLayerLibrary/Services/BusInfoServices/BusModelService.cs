using AutoMapper;
using DataAccessLayer;
using DreamBusDBLayer;

namespace BusinessLayerLibrary.Services.BusInfoServices
{
    public class BusModelService : AGenericService<BusModel, BusModel>
    {
        public BusModelService(IGenericRepository<BusModel> repository) : base(repository)
        {
        }

        protected override IMapper GetMapper()
        {
            return new MapperConfiguration(cfg => { }).CreateMapper();
        }
    }
}
