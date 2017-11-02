using System.Data.Entity.ModelConfiguration;
using Vidly.Models;

namespace Vidly.EntityConfigurations
{
    public class MembershipTypeConfiguration : EntityTypeConfiguration<MembershipType>
    {
        public MembershipTypeConfiguration()
        {
            // Property configuration.
            HasKey(m => m.Id);

            // Relationship configuration
            HasMany(m => m.Customers)
                .WithRequired(c => c.MembershipType)
                .HasForeignKey(c => c.MembershipTypeId);
        }
    }
}