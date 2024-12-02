using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Configuration
{
    public class UserUpdateConfiguration : IEntityTypeConfiguration<UserUpdate>
    {
        public void Configure(EntityTypeBuilder<UserUpdate> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().HasMaxLength(128);
        }
    }
}
