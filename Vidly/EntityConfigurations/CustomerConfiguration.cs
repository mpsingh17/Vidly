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

            Property(c => c.MembershipTypeId)
                .HasColumnName("MembershipId");

            // Relation configuration
            //HasRequired(c => c.MembershipType)
            //    .WithRequiredDependent(m => m.Customer);
        }
    }
}