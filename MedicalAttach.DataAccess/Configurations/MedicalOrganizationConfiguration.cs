using MedicalAttach.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalAttach.DataAccess.Configurations
{
    public class MedicalOrganizationConfiguration : IEntityTypeConfiguration<MedicalOrganizationEntity>
    {
        public void Configure(EntityTypeBuilder<MedicalOrganizationEntity> builder)
        {
            builder.HasKey(mo => mo.Id);

            builder.Property(mo => mo.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasMany(mo => mo.Users)
                .WithOne(u => u.MedicalOrganization)
                .HasForeignKey(u => u.MedicalOrganizationID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
