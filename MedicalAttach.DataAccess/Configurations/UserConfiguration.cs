using MedicalAttach.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .WithMany()
                .HasForeignKey(u => u.MedicalOrganization)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
