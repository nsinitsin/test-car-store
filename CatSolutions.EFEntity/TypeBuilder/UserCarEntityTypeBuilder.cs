using CarSolution.EF7;
using CatSolutions.EFEntity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatSolutions.EFEntity.TypeBuilder
{
    internal class UserCarEntityTypeBuilder : IEntityTypeBuilder<UserCar>
    {
        #region Implementation of IEntityTypeBuilder<UserCar>

        public void Build(EntityTypeBuilder<UserCar> builder)
        {
            builder.HasKey(x => x.PlateNumber).HasName("plate_number");
            
            builder.ToTable("user_car");
        }

        #endregion
    }
}