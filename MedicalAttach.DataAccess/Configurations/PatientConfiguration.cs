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
    public class PatientConfiguration : IEntityTypeConfiguration<PatientEntity>
    {
        public void Configure(EntityTypeBuilder<PatientEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.MiddleName)
                .HasMaxLength(100);

            builder.Property(p => p.IIN)
                .HasMaxLength(12)
                .IsRequired();

            builder.HasIndex(p => p.IIN)
                .IsUnique();

            builder.HasMany(p => p.AttachmentRequests)
                .WithOne(ar => ar.Patient)
                .HasForeignKey(ar => ar.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
