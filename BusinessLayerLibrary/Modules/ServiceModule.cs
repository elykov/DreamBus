using Autofac;
using BusinessLayerLibrary.Models;
using BusinessLayerLibrary.Services;
using DataAccessLayer;
using DataAccessLayer.Repositories;
using DreamBusDBLayer;
using System.Data.Entity;

namespace BusinessLayerLibrary.Modules
{
    //public class ServiceModule : Module
    //{
    //    protected override void Load(ContainerBuilder builder)
    //    {
    //        // City
    //        builder.RegisterType(typeof(CityService))
    //                    .As(typeof(IGenericService<CityDTO>));
    //        builder.RegisterType(typeof(CityRepository))
    //                  .As(typeof(IGenericRepository<City>));

    //        // Region
    //        builder.RegisterType(typeof(RegionService))
    //                    .As(typeof(IGenericService<RegionDTO>));
    //        builder.RegisterType(typeof(RegionRepository))
    //                  .As(typeof(IGenericRepository<Region>));

    //        builder.RegisterType(typeof(DreamBusContext))
    //                 .As(typeof(DbContext)).InstancePerLifetimeScope();
    //    }
    //}
}
