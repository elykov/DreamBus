namespace DreamBusDBLayer
{
    using System.Data.Entity;

    public partial class DreamBusContext : DbContext
    {
        public DreamBusContext()
            : base("name=DreamBusContext")
        {
        }

        public virtual DbSet<Bus> Buses { get; set; }
        public virtual DbSet<BusModel> BusModels { get; set; }
        public virtual DbSet<BusType> BusTypes { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusModel>()
                .HasMany(e => e.Buses)
                .WithRequired(e => e.BusModel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BusType>()
                .Property(e => e.BusStruct)
                .IsUnicode(false);

            modelBuilder.Entity<BusType>()
                .HasMany(e => e.BusModels)
                .WithRequired(e => e.BusType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Region>()
                .HasMany(e => e.Cities)
                .WithRequired(e => e.Region)
                .WillCascadeOnDelete(false);
        }
    }
}
