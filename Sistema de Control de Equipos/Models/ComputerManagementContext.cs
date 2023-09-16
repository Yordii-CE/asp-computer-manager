using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sistema_de_Control_de_Equipos.Models;

public partial class ComputerManagementContext : DbContext
{
    public ComputerManagementContext()
    {
    }

    public ComputerManagementContext(DbContextOptions<ComputerManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Component> Components { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Pc> Pcs { get; set; }

    public virtual DbSet<Problem> Problems { get; set; }

    public virtual DbSet<Responsible> Responsibles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-M29CGA4; Database=computer_management; TrustServerCertificate=True; Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.ToTable("brands");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Component>(entity =>
        {
            entity.ToTable("components");

            entity.HasIndex(e => e.Serial, "IX_components").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BrandId).HasColumnName("brandId");
            entity.Property(e => e.ModelId).HasColumnName("modelId");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PcId).HasColumnName("pcId");
            entity.Property(e => e.Serial)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("serial");
            entity.Property(e => e.Specification)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("specification");

            entity.HasOne(d => d.Brand).WithMany(p => p.Components)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_components_brands");

            entity.HasOne(d => d.Model).WithMany(p => p.Components)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_components_models");

            entity.HasOne(d => d.Pc).WithMany(p => p.Components)
                .HasForeignKey(d => d.PcId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_components_pcs");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("departments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.ToTable("models");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Pc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_pc");

            entity.ToTable("pcs");

            entity.HasIndex(e => e.Serial, "IX_pcs").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateUpdated)
                .HasColumnType("datetime")
                .HasColumnName("date_updated");
            entity.Property(e => e.DepartmentId).HasColumnName("departmentId");
            entity.Property(e => e.Observations)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("observations");
            entity.Property(e => e.Owner)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("owner");
            entity.Property(e => e.ResponsibleId).HasColumnName("responsibleId");
            entity.Property(e => e.Serial)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("serial");

            entity.HasOne(d => d.Department).WithMany(p => p.Pcs)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pcs_departments");

            entity.HasOne(d => d.Responsible).WithMany(p => p.Pcs)
                .HasForeignKey(d => d.ResponsibleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pcs_responsibles");
        });

        modelBuilder.Entity<Problem>(entity =>
        {
            entity.ToTable("problems");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.PcId).HasColumnName("pcId");
        });

        modelBuilder.Entity<Responsible>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_responsible");

            entity.ToTable("responsibles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
