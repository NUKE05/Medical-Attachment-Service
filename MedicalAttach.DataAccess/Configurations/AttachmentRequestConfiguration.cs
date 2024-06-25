using MedicalAttach.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalAttach.Core.Models;

namespace MedicalAttach.DataAccess.Configurations
{
    public class AttachmentRequestConfiguration : IEntityTypeConfiguration<AttachmentRequestEntity>
    {
        public void Configure(EntityTypeBuilder<AttachmentRequestEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(ar => ar.CreationDate)
                .IsRequired();

            builder.Property(ar => ar.ProcessingDate)
                .IsRequired();

            builder.Property(ar => ar.Status)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne<Patient>()
                .WithMany()
                .HasForeignKey(ar => ar.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
