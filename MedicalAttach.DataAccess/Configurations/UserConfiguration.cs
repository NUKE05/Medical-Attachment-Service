using MedicalAttach.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalAttach.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(u => u.Login)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Password)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.IsAdmin)
                .IsRequired();

            builder.HasOne(u => u.MedicalOrganization)
                .WithMany(mo => mo.Users)
                .HasForeignKey(u => u.MedicalOrganizationID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(u => u.Login)
                .IsUnique();
        }
    }
}
