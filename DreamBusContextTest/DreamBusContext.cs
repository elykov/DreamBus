namespace DreamBusContextTest
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DreamBusContext : DbContext
    {
        public DreamBusContext()
            : base("name=DreamBusContext")
        {
        }

        public virtual DbSet<Bus> Buses { get; set; }
        public virtual DbSet<BusModel> BusModels { get; set; }
        public virtual DbSet<BusSeat> BusSeats { get; set; }
        public virtual DbSet<BusType> BusTypes { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<MediumPathe> MediumPathes { get; set; }
        public virtual DbSet<NeighborCity> NeighborCities { get; set; }
        public virtual DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bus>()
                .HasMany(e => e.Flights)
                .WithRequired(e => e.Bus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BusModel>()
                .HasMany(e => e.Buses)
                .WithRequired(e => e.BusModel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BusType>()
                .HasMany(e => e.BusModels)
                .WithRequired(e => e.BusType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BusType>()
                .HasMany(e => e.BusSeats)
                .WithRequired(e => e.BusType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.NeighborCities)
                .WithRequired(e => e.City)
                .HasForeignKey(e => e.CityId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.NeighborCities1)
                .WithRequired(e => e.Neighbor)
                .HasForeignKey(e => e.NeighborId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Flight>()
                .HasMany(e => e.MediumPathes)
                .WithRequired(e => e.Flight)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NeighborCity>()
                .HasMany(e => e.MediumPathes)
                .WithRequired(e => e.NeighborCity)
                .HasForeignKey(e => e.PathId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Region>()
                .HasMany(e => e.Cities)
                .WithRequired(e => e.Region)
                .WillCascadeOnDelete(false);
        }
    }
}
