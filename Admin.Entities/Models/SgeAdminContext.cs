using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Admin.Entities.Models;

public partial class SgeAdminContext : DbContext
{
    public SgeAdminContext(DbContextOptions<SgeAdminContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Arl> Arls { get; set; }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Ceco> Cecos { get; set; }

    public virtual DbSet<ContratosLaborale> ContratosLaborales { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Ep> Eps { get; set; }

    public virtual DbSet<FileRecord> FileRecords { get; set; }

    public virtual DbSet<FondosPensione> FondosPensiones { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<TiposContrato> TiposContratos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Arl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ARL");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<Ceco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("CECO");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<ContratosLaborale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Arlid)
                .HasColumnType("int(11)")
                .HasColumnName("ARLId");
            entity.Property(e => e.CargoId).HasColumnType("int(11)");
            entity.Property(e => e.EmpleadoId).HasColumnType("int(11)");
            entity.Property(e => e.Epsid)
                .HasColumnType("int(11)")
                .HasColumnName("EPSId");
            entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
            entity.Property(e => e.FechaSalida).HasColumnType("datetime");
            entity.Property(e => e.FondoPensionId).HasColumnType("int(11)");
            entity.Property(e => e.HojaVidaRef).HasMaxLength(255);
            entity.Property(e => e.Salario).HasPrecision(10);
            entity.Property(e => e.ServicioId).HasColumnType("int(11)");
            entity.Property(e => e.SoportesRef).HasMaxLength(255);
            entity.Property(e => e.TipoContratoId).HasColumnType("int(11)");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Apellidos)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.ContactoEmergencia).HasColumnType("bigint(20)");
            entity.Property(e => e.CorreoEmpresarial)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.CorreoPersonal)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Guid)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.ModifiedBy)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Nombres)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.NumeroDocumento)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Telefono).HasColumnType("bigint(20)");
            entity.Property(e => e.TelefonoContactoEmergencia).HasColumnType("bigint(20)");
            entity.Property(e => e.TipoDocumento).HasColumnType("int(11)");
        });

        modelBuilder.Entity<Ep>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("EPS");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<FileRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("FileRecord");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ContentType)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.File).HasColumnType("blob");
            entity.Property(e => e.Guid)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Ruta)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<FondosPensione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Cecoid)
                .HasColumnType("int(11)")
                .HasColumnName("CECOId");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<TiposContrato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
