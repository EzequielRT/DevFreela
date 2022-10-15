using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder
                .ToTable("Skill")
            .HasKey(s => s.Id);

            builder
                .ToTable("UserSkill")
                .HasKey(us => us.Id);
        }
    }
}