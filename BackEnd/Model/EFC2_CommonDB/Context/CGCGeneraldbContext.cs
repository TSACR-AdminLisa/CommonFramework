using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace EFC2_CommonDB.Context
{
    public partial class CGCGeneraldbContext : DbContext
    {
        public CGCGeneraldbContext()
        {
        }

        /// <summary>
        /// inicializa el string de conexión a utilizar para el Entity Framework Context DB
        /// </summary>
        /// <param name="paramDBConnectionString">almacena el valor del string de conexión a ser utilizado</param>
        public CGCGeneraldbContext(string paramDBConnectionString)
        {
            ContextConnectionString = paramDBConnectionString;
        }

        /// <summary>
        /// inicializa el string de conexión a utilizar para el Entity Framework Context DB
        /// </summary>
        /// <param name="paramDBConnectionString">almacena el valor del string de conexión a ser utilizado</param>
        public CGCGeneraldbContext(string paramDBConnectionString, DbContextOptions<CGCGeneraldbContext> options)
            : base(options)
        {
            ContextConnectionString = paramDBConnectionString;
        }


        private static string ContextConnectionString { get; set; }

        public static IConfiguration Configuration { get; set; }

        public virtual DbSet<Cantones> Cantones { get; set; }
        public virtual DbSet<Documentos> Documentos { get; set; }
        public virtual DbSet<Modulos> Modulos { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<PermisosModulos> PermisosModulos { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }
        public virtual DbSet<Provincias> Provincias { get; set; }
        public virtual DbSet<RegMovimientos> RegMovimientos { get; set; }
        public virtual DbSet<RegSesion> RegSesion { get; set; }
        public virtual DbSet<RegSesionError> RegSesionError { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<TipoInfoPersonas> TipoInfoPersonas { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<UsuariosRoles> UsuariosRoles { get; set; }
        public virtual DbSet<Errores> Errores { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Data Source=tcp:cgccommon.database.windows.net,1433;Initial Catalog=CGCGeneralDB;Persist Security Info=True;User ID=CGCOwner;Password=Abcd1234..");
                //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("CGCGeneralDB"));
                optionsBuilder.UseSqlServer(ContextConnectionString); //asigna el string de conexión con el cual se inicializa la clase
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cantones>(entity =>
            {
                entity.Property(e => e.Canton).IsUnicode(false);

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Cantones)
                    .HasForeignKey(d => d.IdProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cantones_Provincias");
            });

            modelBuilder.Entity<Documentos>(entity =>
            {
                entity.Property(e => e.ExtensionDoc).IsUnicode(false);

                entity.Property(e => e.NombreDoc).IsUnicode(false);

                entity.Property(e => e.RutaRelativaDoc).IsUnicode(false);
            });

            modelBuilder.Entity<Modulos>(entity =>
            {
                entity.Property(e => e.NombreMod).IsUnicode(false);

                entity.HasOne(d => d.IdModuloPadreNavigation)
                    .WithMany(p => p.InverseIdModuloPadreNavigation)
                    .HasForeignKey(d => d.IdModuloPadre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Modulos_Modulos");
            });

            modelBuilder.Entity<Paises>(entity =>
            {
                entity.Property(e => e.CodigoArea).IsUnicode(false);

                entity.Property(e => e.CodigoPais).IsUnicode(false);

                entity.Property(e => e.Pais).IsUnicode(false);
            });

            modelBuilder.Entity<Permisos>(entity =>
            {
                entity.Property(e => e.CodigoPerm).IsUnicode(false);

                entity.Property(e => e.DescripPerm).IsUnicode(false);

                entity.Property(e => e.NombrePerm).IsUnicode(false);
            });

            modelBuilder.Entity<PermisosModulos>(entity =>
            {
                entity.HasKey(e => new { e.IdModulo, e.IdPermiso });

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.PermisosModulos)
                    .HasForeignKey(d => d.IdModulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PermisosModulos_PermisosModulos");

                entity.HasOne(d => d.IdPermisoNavigation)
                    .WithMany(p => p.PermisosModulos)
                    .HasForeignKey(d => d.IdPermiso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PermisosModulos_Permisos");
            });

            modelBuilder.Entity<Personas>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .IsUnique();

                entity.HasIndex(e => e.Identificacion)
                    .IsUnique();

                entity.Property(e => e.Apellido1).IsUnicode(false);

                entity.Property(e => e.Apellido2).IsUnicode(false);

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.EstadoCivil).IsUnicode(false);

                entity.Property(e => e.Genero).IsUnicode(false);

                entity.Property(e => e.Identificacion).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.TipoIdentificacion).IsUnicode(false);

                entity.HasOne(d => d.IdCantonNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdCanton)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Personas_Cantones");

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.PersonasIdPaisNavigation)
                    .HasForeignKey(d => d.IdPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Personas_Paises");

                entity.HasOne(d => d.IdPaisNacimientoNavigation)
                    .WithMany(p => p.PersonasIdPaisNacimientoNavigation)
                    .HasForeignKey(d => d.IdPaisNacimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Personas_Paises2");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Personas_Provincias");
            });

            modelBuilder.Entity<Provincias>(entity =>
            {
                entity.Property(e => e.IdProvincia).ValueGeneratedOnAdd();

                entity.Property(e => e.Provincia).IsUnicode(false);

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.Provincias)
                    .HasForeignKey(d => d.IdPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Provincias_Paises");
            });

            modelBuilder.Entity<RegMovimientos>(entity =>
            {
                entity.Property(e => e.Detalle).IsUnicode(false);

                entity.Property(e => e.NombreLlavePrimaria).IsUnicode(false);

                entity.Property(e => e.NombreTabla).IsUnicode(false);

                entity.Property(e => e.TipoMovimiento).IsUnicode(false);

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.RegMovimientos)
                    .HasForeignKey(d => d.IdModulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegMovimientos_Modulos");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.DescripcionRol).IsUnicode(false);

                entity.Property(e => e.NombreRol).IsUnicode(false);
            });

            modelBuilder.Entity<Errores>(entity =>
            {
                entity.Property(e => e.Codigo).IsUnicode(false);

                entity.Property(e => e.Detalle).IsUnicode(false);

                entity.Property(e => e.Archivo).IsUnicode(false);

                entity.Property(e => e.Metodo).IsUnicode(false);

                entity.Property(e => e.Fecha).IsUnicode(false);
            });

            modelBuilder.Entity<TipoInfoPersonas>(entity =>
            {
                entity.Property(e => e.TipoDato).IsUnicode(false);

                entity.Property(e => e.TipoInfoPersona).IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.Property(e => e.IdTipoUsuario).ValueGeneratedOnAdd();

                entity.Property(e => e.CodigoTipoU).IsUnicode(false);

                entity.Property(e => e.DescripcionTipoU).IsUnicode(false);

                entity.Property(e => e.TipoUsuario1).IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(e => e.Contrasenia).IsUnicode(false);

                entity.Property(e => e.Usuario).IsUnicode(false);

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Personas");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_TipoUsuario");
            });

            modelBuilder.Entity<UsuariosRoles>(entity =>
            {
                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.UsuariosRoles)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuariosRoles_Roles");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuariosRoles)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuariosRoles_Usuarios");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
