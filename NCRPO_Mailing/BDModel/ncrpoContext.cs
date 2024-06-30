using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NCRPO_Mailing
{
    public partial class ncrpoContext : DbContext
    {
        public ncrpoContext()
        {
        }

        public ncrpoContext(DbContextOptions<ncrpoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Directors> Directors { get; set; }
        public virtual DbSet<Emails> Emails { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Organizations> Organizations { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<Signatures> Signatures { get; set; }
        public virtual DbSet<Types> Types { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Server=localhost;Username=postgres;Password=Ujhbkrf54;Database=ncrpo");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("departments_pkey");

                entity.ToTable("departments");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Directors>(entity =>
            {
                entity.HasKey(e => e.DirectorId)
                    .HasName("directors_pkey");

                entity.ToTable("directors");

                entity.Property(e => e.DirectorId).HasColumnName("director_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Patronymic)
                    .HasColumnName("patronymic")
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Emails>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("emails_pkey");

                entity.ToTable("emails");

                entity.Property(e => e.EmailId).HasColumnName("email_id");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Emails)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("fk_email_department");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("employees_pkey");

                entity.ToTable("employees");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Patronymic)
                    .HasColumnName("patronymic")
                    .HasMaxLength(50);

                entity.Property(e => e.PositionId).HasColumnName("position_id");

                entity.Property(e => e.Surname)
                    .HasColumnName("surname")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_employee_department");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_employee_position");
            });

            modelBuilder.Entity<Organizations>(entity =>
            {
                entity.HasKey(e => e.OrganizationId)
                    .HasName("organizations_pkey");

                entity.ToTable("organizations");

                entity.Property(e => e.OrganizationId).HasColumnName("organization_id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(200);

                entity.Property(e => e.DirectorId).HasColumnName("director_id");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Inn)
                    .HasColumnName("inn")
                    .HasMaxLength(20);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(500);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasMaxLength(20);

                entity.Property(e => e.RegionId).HasColumnName("region_id");

                entity.Property(e => e.ShortName)
                    .HasColumnName("short_name")
                    .HasMaxLength(100);

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.Website)
                    .HasColumnName("website")
                    .HasMaxLength(200);

                entity.HasOne(d => d.Director)
                    .WithMany(p => p.Organizations)
                    .HasForeignKey(d => d.DirectorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_organization_director");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Organizations)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_organization_region");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Organizations)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_organization_type");
            });

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.HasKey(e => e.PositionId)
                    .HasName("positions_pkey");

                entity.ToTable("positions");

                entity.Property(e => e.PositionId).HasColumnName("position_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Regions>(entity =>
            {
                entity.HasKey(e => e.RegionId)
                    .HasName("regions_pkey");

                entity.ToTable("regions");

                entity.Property(e => e.RegionId).HasColumnName("region_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Signatures>(entity =>
            {
                entity.HasKey(e => e.SignatureId)
                    .HasName("signatures_pkey");

                entity.ToTable("signatures");

                entity.Property(e => e.SignatureId).HasColumnName("signature_id");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Signatures)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_signature_department");
            });

            modelBuilder.Entity<Types>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("types_pkey");

                entity.ToTable("types");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
