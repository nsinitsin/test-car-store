using CarSolution.EF7;
using CatSolutions.EFEntity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatSolutions.EFEntity.TypeBuilder
{
    internal class CarEntityTypeBuilder : IEntityTypeBuilder<Car>
    {
        #region Implementation of IEntityTypeBuilder<Car>

        public void Build(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(x => x.Id).HasName("PK_car");
            builder.Property(x => x.Model).HasColumnName("model").IsRequired();
            builder.Property(x => x.Date).HasColumnName("date").IsRequired();

            builder.HasMany(x => x.UserCars).WithOne(x => x.Car).HasForeignKey(x => x.CarId).HasConstraintName("FK_car_plnumid__usercar_platenumber");

            builder.ToTable("car");
        }

        #endregion
    }
}