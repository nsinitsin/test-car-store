using CarSolution.EF7;
using CatSolutions.EFEntity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatSolutions.EFEntity.TypeBuilder
{
    internal class UserEntityTypeBuilder : IEntityTypeBuilder<User>
    {
        #region Implementation of IEntityTypeBuilder<User>

        public void Build(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id).HasName("PK_id");
            builder.Property(x => x.Email).HasColumnName("email").IsRequired();
            builder.Property(x => x.Name).HasColumnName("name").IsRequired();

            builder.HasMany(x => x.UserCars).WithOne(x => x.User).HasForeignKey(x => x.UserId).HasConstraintName("FK_user_usercarid__usercar_platenumber");

            builder.ToTable("user");
        }

        #endregion
    }
}