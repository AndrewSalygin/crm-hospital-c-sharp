using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.DbModels;

public partial class DefaultDbContext : DbContext
{
    public DefaultDbContext()
    {
    }

    public DefaultDbContext(DbContextOptions<DefaultDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<DoctorSpecialization> DoctorSpecializations { get; set; }

    public virtual DbSet<DoctorSurgeryJournal> DoctorSurgeryJournals { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    public virtual DbSet<Surgery> Surgeries { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-1V25VNM;Initial Catalog=shospital;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Cyrillic_General_100_CI_AI");

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.ToTable("doctor");

            entity.HasIndex(e => e.PhoneNumber, "UQ__doctor__4849DA0182663930").IsUnique();

            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("dateOfBirth");
            entity.Property(e => e.Education)
                .IsRequired()
                .HasColumnType("text")
                .HasColumnName("education");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("emailAddress");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.Gender)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.MiddleName)
                .IsRequired()
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("middleName");
            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
        });

        modelBuilder.Entity<DoctorSpecialization>(entity =>
        {
            entity.ToTable("doctorSpecialization");

            entity.Property(e => e.DoctorId).HasColumnName("doctorId");
            entity.Property(e => e.SpecializationId).HasColumnName("specializationId");
            entity.Property(e => e.YearsOfExperience).HasColumnName("yearsOfExperience");

            entity.HasOne(d => d.Doctor).WithMany(p => p.DoctorSpecializations)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_doctorSpecialization_doctor");

            entity.HasOne(d => d.Specialization).WithMany(p => p.DoctorSpecializations)
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_doctorSpecialization_specialization");
        });

        modelBuilder.Entity<DoctorSurgeryJournal>(entity =>
        {
            entity.ToTable("doctorSurgeryJournal");

            entity.Property(e => e.DoctorId).HasColumnName("doctorId");
            entity.Property(e => e.ScheduledWorkingHours).HasColumnName("scheduledWorkingHours");
            entity.Property(e => e.SurgeryId).HasColumnName("surgeryId");
            entity.Property(e => e.WorkingHours).HasColumnName("workingHours");

            entity.HasOne(d => d.Doctor).WithMany(p => p.DoctorSurgeryJournals)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_doctorSurgeryJournal_doctor");

            entity.HasOne(d => d.Surgery).WithMany(p => p.DoctorSurgeryJournals)
                .HasForeignKey(d => d.SurgeryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_doctorSurgeryJournal_surgery");
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.ToTable("specialization");

            entity.HasIndex(e => e.SpecializationName, "UQ__speciali__E8C2CCDF512DCE48").IsUnique();

            entity.Property(e => e.SpecializationName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("specializationName");
        });

        modelBuilder.Entity<Surgery>(entity =>
        {
            entity.ToTable("surgery");

            entity.Property(e => e.Emergency).HasColumnName("emergency");
            entity.Property(e => e.EndTime).HasColumnName("endTime");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.ScheduledDateTime).HasColumnName("scheduledDateTime");
            entity.Property(e => e.StartTime).HasColumnName("startTime");
            entity.Property(e => e.SurgeryType)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("surgeryType");
            entity.Property(e => e.SurgicalProcedureDescription)
                .HasColumnType("text")
                .HasColumnName("surgicalProcedureDescription");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Login, "Unique_Users_Login").IsUnique();

            entity.Property(e => e.Login)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.Password).IsRequired();
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
