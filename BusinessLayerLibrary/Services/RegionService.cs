using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using BusinessLayerLibrary.Models;
using DataAccessLayer;
using DreamBusDBLayer;

namespace BusinessLayerLibrary.Services
{
    public class RegionService : AGenericService<Region, RegionDTO>
    {
        public RegionService(IGenericRepository<Region> repository) : base(repository)
        {
        }

        protected override IMapper GetMapper()
        {
            return new MapperConfiguration(cfg => {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Region, RegionDTO>();
                cfg.CreateMap<RegionDTO, Region>();
            }).CreateMapper();
        }
    }
}
