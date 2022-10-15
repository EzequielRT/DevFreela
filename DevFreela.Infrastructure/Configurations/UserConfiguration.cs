using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("User")
                .HasKey(s => s.Id);

            builder
                .HasMany(u => u.Skills)
                .WithOne()
                .HasForeignKey(us => us.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}