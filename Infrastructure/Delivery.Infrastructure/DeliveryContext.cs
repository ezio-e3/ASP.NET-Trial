
using Delivery.Domain;
using Delivery.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Infrastructure
{
    public class DeliveryContext : BaseDeliveryContext
    {
        //public  DbSet<Rider> Riders { get; set; }
        public DeliveryContext(DbContextOptions<DeliveryContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Rider>().Property(r => r.Name).HasMaxLength(50);
            //modelBuilder.ApplyConfiguration(new RiderConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DeliveryContext).Assembly);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            //optionsBuilder.
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(50);
        }
    }
}
