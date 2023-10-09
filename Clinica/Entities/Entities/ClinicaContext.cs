using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Entities
{
    public partial class ClinicaContext : DbContext
    {
        public ClinicaContext()
        {
        }

        public ClinicaContext(DbContextOptions<ClinicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cita> Citas { get; set; } = null!;
        public virtual DbSet<Clinica> Clinicas { get; set; } = null!;
        public virtual DbSet<Diagnostico> Diagnosticos { get; set; } = null!;
        public virtual DbSet<Doctore> Doctores { get; set; } = null!;
        public virtual DbSet<Especialidade> Especialidades { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Horario> Horarios { get; set; } = null!;
        public virtual DbSet<Precio> Precios { get; set; } = null!;
        public virtual DbSet<Reserva> Reservas { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<StatusReserva> StatusReservas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-DJD7T3K;Database=Clinica;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>(entity =>
            {
                entity.HasKey(e => e.IdCita)
                    .HasName("PK__Citas__394B0202AE1504BF");

                entity.Property(e => e.StatusCita).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__Citas__IdClinica__3A81B327");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdDoctor)
                    .HasConstraintName("FK__Citas__IdDoctor__38996AB5");

                entity.HasOne(d => d.IdEspecialidadNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdEspecialidad)
                    .HasConstraintName("FK__Citas__IdEspecia__398D8EEE");

                entity.HasOne(d => d.IdHorarioNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdHorario)
                    .HasConstraintName("FK__Citas__IdHorario__3B75D760");
            });

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PK__Clinicas__52A909518C1B9C25");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Diagnostico>(entity =>
            {
                entity.HasKey(e => e.IdDiagnostico)
                    .HasName("PK__Diagnost__BD16DB69B1336B29");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.HasOne(d => d.IdReservaNavigation)
                    .WithMany(p => p.Diagnosticos)
                    .HasForeignKey(d => d.IdReserva)
                    .HasConstraintName("FK__Diagnosti__IdRes__4AB81AF0");
            });

            modelBuilder.Entity<Doctore>(entity =>
            {
                entity.HasKey(e => e.IdDoctor)
                    .HasName("PK__Doctores__F838DB3E27A2546A");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusDoctor).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidad)
                    .HasName("PK__Especial__693FA0AF3F1B3C1F");

                entity.Property(e => e.IdEspecialidad).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusEspecialidad).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdPrecioNavigation)
                    .WithMany(p => p.Especialidades)
                    .HasForeignKey(d => d.IdPrecio)
                    .HasConstraintName("FK__Especiali__IdPre__2D27B809");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PK__Facturas__50E7BAF1B4A75799");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdReservaNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdReserva)
                    .HasConstraintName("FK__Facturas__IdRese__46E78A0C");
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.HasKey(e => e.IdHorario)
                    .HasName("PK__Horarios__1539229B6E5900DF");

                entity.Property(e => e.Dia)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Hora)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StatusHorario).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Precio>(entity =>
            {
                entity.HasKey(e => e.IdPrecio)
                    .HasName("PK__Precios__2450584BB128902B");

                entity.Property(e => e.IdPrecio).ValueGeneratedNever();
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.IdReserva)
                    .HasName("PK__Reservas__0E49C69D05B85E9F");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdCitaNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdCita)
                    .HasConstraintName("FK__Reservas__IdCita__412EB0B6");

                entity.HasOne(d => d.IdStatusReservaNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdStatusReserva)
                    .HasConstraintName("FK__Reservas__IdStat__4316F928");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Reservas__IdUsua__4222D4EF");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Roles__2A49584CC50FFF4E");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusReserva>(entity =>
            {
                entity.HasKey(e => e.IdStatusReserva)
                    .HasName("PK__StatusRe__89FBDF167EE2677A");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF97A9D2EDD1");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StatusUsuario).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK__Usuarios__IdRol__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
