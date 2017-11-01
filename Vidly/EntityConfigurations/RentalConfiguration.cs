using System.Data.Entity.ModelConfiguration;
using Vidly.Models;

namespace Vidly.EntityConfigurations
{
    public class RentalConfiguration : EntityTypeConfiguration<Rental>
    {
        public RentalConfiguration()
        {
        }
    }
}