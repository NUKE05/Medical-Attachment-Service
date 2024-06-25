using MedicalAttach.Core.Models;
using MedicalAttach.DataAccess.Configurations;
using MedicalAttach.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MedicalAttach.DataAccess
{
    public class MedicalAttachDbContext : DbContext
    {
        public MedicalAttachDbContext(DbContextOptions<MedicalAttachDbContext> options) : base(options)
        {
        }

        public DbSet<PatientEntity> Patients { get; set; }
        public DbSet<MedicalOrganizationEntity> MedicalOrganizations { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AttachmentRequestEntity> AttachmentRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new MedicalOrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AttachmentRequestConfiguration());
        }
    }
}
