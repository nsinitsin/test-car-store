using CarSolution.EF7;
using CatSolutions.EFEntity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatSolutions.EFEntity.TypeBuilder
{
    internal class ManufacturerEntityTypeBuilder : IEntityTypeBuilder<Manufacturer>
    {
        #region Implementation of IEntityTypeBuilder<Manufacturer>

        public void Build(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.HasKey(x => x.Id).HasName("PK_id");
            builder.Property(x => x.Country).HasColumnName("country").IsRequired();
            builder.Property(x => x.Name).HasColumnName("name").IsRequired();

            builder.HasMany(x => x.Cars).WithOne(x => x.Manufacturer).HasForeignKey(x=>x.ManufacturerId).HasConstraintName("FK_car_id__manufacturer_carid");

            builder.ToTable("manufacturer");
        }

        #endregion
    }
}