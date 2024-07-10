using Identity.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.API.Database.Configuration
{
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(i => i.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(i => i.LastName).IsRequired().HasMaxLength(50);
        }
    }
}
