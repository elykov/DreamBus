using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using BusinessLayerLibrary.Models;
using DataAccessLayer;
using DreamBusDBLayer;

namespace BusinessLayerLibrary.Services
{


    public class CityService : AGenericService<City, CityDTO>
    {
        public CityService(IGenericRepository<City> repository) : base(repository)
        {
        }

        protected override IMapper GetMapper()
        {
            return new MapperConfiguration(cfg => {
                cfg.AddExpressionMapping();
                cfg.CreateMap<City, CityDTO>()
                .ForMember("RegionTitle", opt => opt.MapFrom(city => city.Region.Title ));
                cfg.CreateMap<CityDTO, City>();
            }).CreateMapper();
        }
    }
}
