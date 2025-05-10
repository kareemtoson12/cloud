using Microsoft.EntityFrameworkCore;
using HealthcareManagement.Shared.Models;

namespace EHR.API.Data
{
    public class EHRDbContext : DbContext
    {
        public EHRDbContext(DbContextOptions<EHRDbContext> options)
            : base(options)
        {
        }

        public DbSet<MedicalRecord> MedicalRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalRecord>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PatientId).IsRequired();
                entity.Property(e => e.DoctorId).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Diagnosis).HasMaxLength(500);
                entity.Property(e => e.Treatment).HasMaxLength(1000);
                entity.Property(e => e.Prescription).HasMaxLength(500);
                entity.Property(e => e.Notes).HasMaxLength(1000);
                entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
                
                // Configure the Attachments as a JSON column
                entity.Property(e => e.Attachments)
                    .HasConversion(
                        v => System.Text.Json.JsonSerializer.Serialize(v, (System.Text.Json.JsonSerializerOptions?)null),
                        v => System.Text.Json.JsonSerializer.Deserialize<List<string>>(v, (System.Text.Json.JsonSerializerOptions?)null));
            });
        }
    }
} 