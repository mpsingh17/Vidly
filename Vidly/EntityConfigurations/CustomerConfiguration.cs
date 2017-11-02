using System.Data.Entity.ModelConfiguration;
using Vidly.Models;

namespace Vidly.EntityConfigurations
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            // Property configuration.
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(c => c.BirthDate)
                .IsOptional();

            Property(c => c.ProfileImagePath)
                .IsOptional();

            // Relationship configuration
            HasMany(c => c.Rentals)
                .WithRequired(r => r.Customer)
                .HasForeignKey(r => r.CustomerId);
        }
    }
}