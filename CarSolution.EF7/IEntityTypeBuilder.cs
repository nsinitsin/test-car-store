using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSolution.EF7
{
    public interface IEntityTypeBuilder<T> where T : class
    {
        void Build(EntityTypeBuilder<T> builder);
    }
}