using System.Data.Entity.ModelConfiguration;
using Vidly.Models;

namespace Vidly.EntityConfigurations
{
    public class MovieConfiguration : EntityTypeConfiguration<Movie>
    {
        public MovieConfiguration()
        {
            // Property Configuration.
            Property(m => m.Name)
                .HasMaxLength(255)
                .IsRequired();

            
        }
    }
}