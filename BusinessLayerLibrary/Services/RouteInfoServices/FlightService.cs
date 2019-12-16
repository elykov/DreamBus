using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using BusinessLayerLibrary.Models;
using DataAccessLayer;
using DreamBusDBLayer;
using System.Linq;

namespace BusinessLayerLibrary.Services
{
    public class FlightService : AGenericService<Flight, FlightDTO>
    {
        public FlightService(IGenericRepository<Flight> repository) : base(repository)
        {
        }

        protected override IMapper GetMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Flight, FlightDTO>();

                //.ForMember("DepartureTime", opt => opt.MapFrom(
                //    flight => flight.MediumPathes.
                //                Where(mp => mp.PathNum == 0).FirstOrDefault().DepartureTime));

                //.ForMember("StartCity", opt => opt.MapFrom(
                //    flight => flight.MediumPathes.
                //        Where(mp => mp.PathNum == 0).FirstOrDefault().NeighborCity.City));
                //.ForMember("EndCity", opt => opt.MapFrom(
                //    flight => flight.MediumPathes.OfType<MediumPathe>()
                //        //.LastOrDefault() 
                //        //Aggregate((e1, e2) => e1.PathNum > e2.PathNum ? e1 : e2)
                //        .NeighborCity.Neighbor));
                //.ForMember("ArrivalTime", opt => opt.MapFrom(flight =>
                //    flight.MediumPathes.OfType<MediumPathe>().
                //    Aggregate((e1, e2) => e1.PathNum > e2.PathNum ? e1 : e2).ArrivalTime));
                cfg.CreateMap<FlightDTO, Flight>();
            }).CreateMapper();
        }
    }
}
