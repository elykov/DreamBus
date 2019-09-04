using BusinessLayerLibrary.Services;
using BusinessLayerLibrary.Services.BusInfoServices;
using DataAccessLayer.Repositories;
using DreamBusDBLayer;

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
        public BusSeatService BusSeatService { get; }
        public BusTypeService BusTypeService { get; }
        public BusModelService BusModelService { get; }
        public BusService BusService { get; }

        public DbConnector()
        {
            context = new DreamBusContext();
            CityService = new CityService(new CityRepository(context));
            RegionService = new RegionService(new RegionRepository(context));
            NeighborCitiesService = new NeighborCityService(new NeighborCityRepository(context));
            FlightService = new FlightService(new FlightRepository(context));
            MediumPathService = new MediumPathService(new MediumPathRepository(context));
            BusSeatService = new BusSeatService(new BusSeatRepository(context));
            BusTypeService = new BusTypeService(new BusTypeRepository(context));
            BusModelService = new BusModelService(new BusModelRepository(context));
            BusService = new BusService(new BusRepository(context));
        }
    }
}
