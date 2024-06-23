using MedicalAttach.Core.Models;
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

        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalOrganization> MedicalOrganizations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AttachmentRequest> AttachmentRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.MiddleName).HasMaxLength(100);
                entity.Property(e => e.IIN).IsRequired().HasMaxLength(12);
                entity.HasOne(e => e.MedicalOrganization)
                      .WithMany(m => m.Patients)
                      .HasForeignKey(e => e.MedicalOrganizationId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<MedicalOrganization>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(250);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Login).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(100);
                entity.Property(e => e.IsAdmin).IsRequired();
                entity.HasOne(e => e.MedicalOrganization)
                      .WithMany(m => m.Users)
                      .HasForeignKey(e => e.MedicalOrganizationId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AttachmentRequest>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CreationDate).IsRequired();
                entity.Property(e => e.ProcessingDate).IsRequired();
                entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
                entity.HasOne(e => e.Patient)
                      .WithMany(p => p.AttachmentRequests)
                      .HasForeignKey(e => e.PatientId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
