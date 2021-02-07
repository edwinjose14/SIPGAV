using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SIPGAV.Models
{
    public partial class SIPGAVContext : DbContext
    {
        public SIPGAVContext()
        {
        }

        public SIPGAVContext(DbContextOptions<SIPGAVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<Finca> Fincas { get; set; }
        public virtual DbSet<Ganado> Ganados { get; set; }
        public virtual DbSet<Maquina> Maquinas { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<RolUsuario> RolUsuarios { get; set; }
        public virtual DbSet<Trabajador> Trabajadors { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=EDWIN;Database=SIPGAV;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdFinca)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("idFinca");

                entity.HasOne(d => d.IdFincaNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.IdFinca)
                    .HasConstraintName("FK_Eventos_Finca");
            });

            modelBuilder.Entity<Finca>(entity =>
            {
                entity.HasKey(e => e.NumeroRegistro);

                entity.ToTable("Finca");

                entity.Property(e => e.NumeroRegistro)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numeroRegistro");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaIngreso");

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("foto");

                entity.Property(e => e.Hectareas)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("hectareas");

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("idUsuario");

                entity.Property(e => e.NombreFinca)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreFinca");

                entity.Property(e => e.Ubicacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ubicacion");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Fincas)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Finca_usuario");
            });

            modelBuilder.Entity<Ganado>(entity =>
            {
                entity.ToTable("Ganado");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdFinca)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("idFinca");

                entity.Property(e => e.Raza)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("raza");

                entity.Property(e => e.TipoAnimal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipoAnimal");

                entity.Property(e => e.Vacunas)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("vacunas");

                entity.HasOne(d => d.IdFincaNavigation)
                    .WithMany(p => p.Ganados)
                    .HasForeignKey(d => d.IdFinca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ganado_Finca");
            });

            modelBuilder.Entity<Maquina>(entity =>
            {
                entity.ToTable("Maquina");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Cilindraje)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cilindraje");

                entity.Property(e => e.Combustible)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("combustible");

                entity.Property(e => e.IdFinca)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("idFinca");

                entity.Property(e => e.Tarea)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tarea");

                entity.Property(e => e.TipoMaquina)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipoMaquina");

                entity.HasOne(d => d.IdFincaNavigation)
                    .WithMany(p => p.Maquinas)
                    .HasForeignKey(d => d.IdFinca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_maquina_Finca");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Rol1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rol");
            });

            modelBuilder.Entity<RolUsuario>(entity =>
            {
                entity.ToTable("Rol_Usuario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("idUsuario");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.RolUsuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rol_Usuario_Rol");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.RolUsuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rol_Usuario_Usuario");
            });

            modelBuilder.Entity<Trabajador>(entity =>
            {
                entity.HasKey(e => e.Identificacion)
                    .HasName("PK_trabajador");

                entity.ToTable("Trabajador");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("identificacion");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Eps)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("eps");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaIngreso");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaNacimiento");

                entity.Property(e => e.FechaSalida)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaSalida");

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("foto");

                entity.Property(e => e.IdFinca)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("idFinca");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombres");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("primerApellido");

                entity.Property(e => e.Salario)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("salario");

                entity.Property(e => e.SegundoApellido)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("segundoApellido");

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sexo");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdFincaNavigation)
                    .WithMany(p => p.Trabajadors)
                    .HasForeignKey(d => d.IdFinca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trabajador_Finca");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Identificacion)
                    .HasName("PK_usuario");

                entity.ToTable("Usuario");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("identificacion");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaIngreso");

                entity.Property(e => e.Foto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("foto");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombres");

                entity.Property(e => e.NumeroFincas).HasColumnName("numeroFincas");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("primerApellido");

                entity.Property(e => e.SegundoApellido)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("segundoApellido");

                entity.Property(e => e.Telefono1)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("telefono1");

                entity.Property(e => e.Telefono2)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("telefono2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
