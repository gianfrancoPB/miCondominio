using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace miCondominio.Models
{
    public partial class miCondominioContext : DbContext
    {
        public miCondominioContext()
        {
        }

        //public miCondominioContext(DbContextOptions<miCondominioContext> options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<Departamento> Departamentos { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
                optionsBuilder.UseSqlServer("Server=.;Database=miCondominio;Uid=sa;Password=12345678;Encrypt=false;");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento)
                    .HasName("PK__Departam__787A433D28689CB3");

                entity.ToTable("Departamento");

                entity.Property(e => e.IdDepartamento).ValueGeneratedNever();

                entity.Property(e => e.BAmoblado).HasColumnName("bAmoblado");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Dni)
                    .HasName("PK__Persona__C035B8DCDD2F8819");

                entity.ToTable("Persona");

                entity.Property(e => e.Dni)
                    .ValueGeneratedNever()
                    .HasColumnName("DNI");

                entity.Property(e => e.ApellidoMat)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPat)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdDepartamento)
                    .HasConstraintName("FK__Persona__IdDepar__2A4B4B5E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
