using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Configurations
{
    public class ProjectCommentConfiguration : IEntityTypeConfiguration<ProjectComment>
    {
        public void Configure(EntityTypeBuilder<ProjectComment> builder)
        {
            builder
                .ToTable("ProjectComment")
                .HasKey(pc => pc.Id);

            builder
                .HasOne(pc => pc.Project)
                .WithMany(p => p.Comments)
                .HasForeignKey(pc => pc.IdProject)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(pc => pc.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(pc => pc.IdUser)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}