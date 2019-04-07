using CatSolutions.EFEntity.Models;
using CatSolutions.EFEntity.TypeBuilder;
using Microsoft.EntityFrameworkCore;

namespace CatSolutions.EFEntity
{
    public class CarSlnDbContext :DbContext
    {
        public CarSlnDbContext()
        {
            
        }

        public CarSlnDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<UserCar> UserCars { get; set; }
        public DbSet<User> Users { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new CarEntityTypeBuilder().Build(modelBuilder.Entity<Car>());
            new ManufacturerEntityTypeBuilder().Build(modelBuilder.Entity<Manufacturer>());
            new UserCarEntityTypeBuilder().Build(modelBuilder.Entity<UserCar>());
            new UserEntityTypeBuilder().Build(modelBuilder.Entity<User>());

        }
    }
}