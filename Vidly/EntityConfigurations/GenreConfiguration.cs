using System.Data.Entity.ModelConfiguration;
using Vidly.Models;

namespace Vidly.EntityConfigurations
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            // Property configuration.
            Property(g => g.Name)
                .HasMaxLength(255)
                .IsRequired();

            // One to many relation with movies.
            HasMany(g => g.Movies)
                .WithRequired(m => m.Genre)
                .HasForeignKey(m => m.GenreId);

        }
    }
}