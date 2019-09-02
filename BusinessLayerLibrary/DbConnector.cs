using BusinessLayerLibrary.Services;
using DataAccessLayer.Repositories;
using DreamBusDBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerLibrary
{
    public class DbConnector
    {
        DreamBusContext context;
        public CityService CityService { get; }
        public RegionService RegionService { get; }
        public NeighborCityService NeighborCitiesService { get; }
        public MediumPathService MediumPathService { get; }
        public FlightService FlightService { get; }


        public DbConnector()
        {
            context = new DreamBusContext();
            CityService = new CityService(new CityRepository(context));
            RegionService = new RegionService(new RegionRepository(context));
            NeighborCitiesService = new NeighborCityService(new NeighborCityRepository(context));
            FlightService = new FlightService(new FlightRepository(context));
            MediumPathService = new MediumPathService(new MediumPathRepository(context));
        }
    }
}
