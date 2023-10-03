using ChallengeMVFactory.Domain;
using ChallengeMVFactory.Domain.Common;
using Microsoft.EntityFrameworkCore;
 

namespace ChallengeMVFactory.Infrastructure.Persistence
{
    public class MVFactoryDbContext : DbContext
    {
        public MVFactoryDbContext(DbContextOptions<MVFactoryDbContext> options) : base(options)
        {

        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<BaseModel>())
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        item.Entity.createDate = DateTime.Now;
                        item.Entity.createdBy = "system";
                        break;
                    case EntityState.Modified:
                        item.Entity.updateDate = DateTime.Now;
                        item.Entity.updateBy = "system";
                        break;
                }

            }
            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             
            modelBuilder.Entity<City>()
                .HasMany(a => a.History)
                .WithOne(a => a.City)
                .HasForeignKey(a => a.CiyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

           modelBuilder.Entity<Country>()
          .HasMany(a => a.Citys)
          .WithOne(a => a.Country)
          .HasForeignKey(a => a.CountryId)
          .IsRequired()
         .OnDelete(DeleteBehavior.Restrict);



            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Country> Countrys { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<HistoryWeatherCity> HistoryWeatherCitys { get; set; }
    }
}
