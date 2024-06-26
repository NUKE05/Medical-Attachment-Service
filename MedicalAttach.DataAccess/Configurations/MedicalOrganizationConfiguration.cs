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
    public class MedicalOrganizationConfiguration : IEntityTypeConfiguration<MedicalOrganizationEntity>
    {
        public void Configure(EntityTypeBuilder<MedicalOrganizationEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);
            builder.HasIndex(e => e.Name);
        }
    }
}
