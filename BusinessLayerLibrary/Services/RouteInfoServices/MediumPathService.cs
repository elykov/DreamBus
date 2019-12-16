using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using BusinessLayerLibrary.Models;
using DataAccessLayer;
using DreamBusDBLayer;

namespace BusinessLayerLibrary.Services
{
    public class MediumPathService : AGenericService<MediumPathe, MediumPathDTO>
    {
        public MediumPathService(IGenericRepository<MediumPathe> repository) : base(repository)
        {
        }

        protected override IMapper GetMapper()
        {
            return new MapperConfiguration(cfg => {
                cfg.AddExpressionMapping();
                cfg.CreateMap<MediumPathe, MediumPathDTO>();
                //.ForMember("ArrivalTime", opt => opt.MapFrom(
                //    mp => mp.DepartureTime.Add(new System.TimeSpan(0, mp.NeighborCity.MinutesInPath, 0))));
                cfg.CreateMap<MediumPathDTO, MediumPathe>();
            }).CreateMapper();
        }
    }
}
