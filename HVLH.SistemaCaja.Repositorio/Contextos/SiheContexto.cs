using HVLH.SistemaCaja.Comun;
using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Repositorio.Contratos;
using HVLH.SistemaCaja.Repositorio.Impl;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using TipoDocumento = HVLH.SistemaCaja.Modelo.TipoDocumento;

namespace HVLH.SistemaCaja.Repositorio.Contextos
{
	public class SiheContexto : DbContext, ISiheContexto
	{

		public SiheContexto(DbContextOptions<SiheContexto> options) : base(options)
		{
			RepositorioConfiguracion = new RepositorioConfiguracion(this);
			RepositorioCorrelativoSerie = new RepositorioCorrelativoSerie(this);
			RepositorioDocumento = new RepositorioDocumento(this);
			RepositorioPreventa = new RepositorioPreventa(this);
			RepositorioTipoDocumento = new RepositorioTipoDocumento(this);
			RepositorioTipoDocumentoSerie = new RepositorioTipoDocumentoSerie(this);
			RepositorioTipoMedioPago = new RepositorioTipoMedioPago(this);
			RepositorioTipoOperacion = new RepositorioTipoOperacion(this);
			RepositorioCatalagoServicio = new RepositorioCatalagoServicio(this);
			RepositorioUsuario = new RepositorioUsuario(this);
			RepositorioRol = new RepositorioRol(this);
			RepositorioMenu = new RepositorioMenu(this);
			RepositorioPaciente = new RepositorioPaciente(this);
			RepositorioResumen = new RepositorioResumen(this);
			RepositorioComunicacionBaja = new RepositorioComunicacionBaja(this);
			RepositorioCita = new RepositorioCita(this);
			RepositorioDocumentoCita = new RepositorioDocumentoCita(this);
			RepositorioProducto = new RepositorioProducto(this);
			RepositorioTipoAfectacionIgv = new RepositorioTipoAfectacionIgv(this);
			RepositorioUnidadMedida = new RepositorioUnidadMedida(this);
			RepositorioDocumentoDetalle = new RepositorioDocumentoDetalle(this);
			RepositorioCuota = new RepositorioCuota(this);
			RepositorioMedioPagoDocumento = new RepositorioMedioPagoDocumento(this);
		}
		public IRepositorioConfiguracion RepositorioConfiguracion { get; private set; }
		public IRepositorioCorrelativoSerie RepositorioCorrelativoSerie { get; private set; }
		public IRepositorioDocumento RepositorioDocumento { get; private set; }
		public IRepositorioPreventa RepositorioPreventa { get; private set; }
		public IRepositorioTipoDocumento RepositorioTipoDocumento { get; private set; }
		public IRepositorioTipoDocumentoSerie RepositorioTipoDocumentoSerie { get; private set; }
		public IRepositorioTipoMedioPago RepositorioTipoMedioPago { get; private set; }
		public IRepositorioTipoOperacion RepositorioTipoOperacion { get; private set; }
		public IRepositorioCatalagoServicio RepositorioCatalagoServicio { get; private set; }
		public IRepositorioUsuario RepositorioUsuario { get; private set; }
		public IRepositorioRol RepositorioRol { get; private set; }
		public IRepositorioMenu RepositorioMenu { get; private set; }
		public IRepositorioPaciente RepositorioPaciente { get; private set; }
		public IRepositorioResumen RepositorioResumen { get; private set; }
		public IRepositorioComunicacionBaja RepositorioComunicacionBaja { get; private set; }
		public IRepositorioCita RepositorioCita { get; private set; }
		public IRepositorioDocumentoCita RepositorioDocumentoCita { get; private set; }
		public IRepositorioProducto RepositorioProducto { get; private set; }
		public IRepositorioTipoAfectacionIgv RepositorioTipoAfectacionIgv { get; private set; }
		public IRepositorioUnidadMedida RepositorioUnidadMedida { get; private set; }
		public IRepositorioDocumentoDetalle RepositorioDocumentoDetalle { get; private set; }
		public IRepositorioCuota RepositorioCuota { get; private set; }
		public IRepositorioMedioPagoDocumento RepositorioMedioPagoDocumento { get; private set; }

		public bool Commit()
		{
			return SaveChanges() > 0;
		}

		public async Task<bool> CommitAsync()
		{
			var filasAfectadas = await SaveChangesAsync();
			return filasAfectadas > 0;
		}

		public bool ValidarConexion()
		{
			return Database.CanConnect();
		}

		public void RefreshAll()
		{
			ChangeTracker
			.Entries()
			.ToList()
			.ForEach(x => x.Reload());
		}

		public DbSet<TipoDocumento> TipoDocumentos { get; set; }
		public DbSet<TipoDocumentoSerie> TipoDocumentoSeries { get; set; }
		public DbSet<PreventaResult> PreventaResult { get; set; }
		public DbSet<CorrelativoSerie> CorrelativoSeries { get; set; }
		public DbSet<Documento> Documentos { get; set; }
		public DbSet<Configuracion> Configuracion { get; set; }
		public DbSet<TipoMedioPago> TipoMedioPagos { get; set; }
		public DbSet<MedioPagoDocumento> MedioPagoDocumento { get; set; }
		public DbSet<Cuota> Cuotas { get; set; }
		public DbSet<TipoOperacion> TipoOperaciones { get; set; }
		public DbSet<CatalogoServicioResult> CatalogoServicioResult { get; set; }
		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Menu> Menus { get; set; }
		public DbSet<Rol> Roles { get; set; }
		public DbSet<RolMenu> RolMenu { get; set; }
		public DbSet<UsuarioRol> UsuarioRoles { get; set; }
		public DbSet<Paciente> Pacientes { get; set; }
		public DbSet<Resumen> Resumenes { get; set; }
		public DbSet<ResumenDetalle> ResumenDetalles { get; set; }
		public DbSet<ComunicacionBaja> ComunicacionBajas { get; set; }
		public DbSet<ComunicacionBajaDetalle> ComunicacionBajaDetalles { get; set; }
		public DbSet<CitasResult> Citas { get; set; }
		public DbSet<DocumentoCita> DocumentoCitas { get; set; }
		public DbSet<Producto> Productos { get; set; }
		public DbSet<DocumentoDetalle> DocumentoDetalles { get; set; }
		public DbSet<UnidadMedida> UnidadMedidas { get; set; }
		public DbSet<TipoAfectacionIgv> TipoAfectacionIgv { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["SiheDB"].ConnectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PreventaResult>(entity =>
					entity.HasNoKey());

			modelBuilder.Entity<Documento>()
				.HasOne(x => x.MedioPagoDocumento)
				.WithOne(x => x.Documento)
				.HasForeignKey<MedioPagoDocumento>(x => x.IdDocumento);

			modelBuilder.Entity<Documento>()
				.HasMany(x => x.Detalles)
				.WithOne(x => x.Documento)
				.HasForeignKey(x => x.IdDocumento);

			modelBuilder.Entity<CatalogoServicioResult>(entity =>
					entity.HasNoKey());

			modelBuilder.Entity<Documento>()
				.HasMany(x => x.Cuotas)
				.WithOne(x => x.Documento)
				.HasForeignKey(x => x.IdDocumento);

			modelBuilder.Entity<Usuario>()
				.Property(x => x.Estado)
				.HasDefaultValue(Estado.Activo)
				.HasConversion<int>();

			modelBuilder.Entity<RolMenu>()
				.HasOne(rm => rm.Menu)
				.WithMany(m => m.RolMenus)
				.HasForeignKey(rm => rm.IdMenu);

			modelBuilder.Entity<RolMenu>()
				.HasOne(rm => rm.Rol)
				.WithMany(r => r.RolMenus)
				.HasForeignKey(rm => rm.IdRol);

			modelBuilder.Entity<UsuarioRol>()
				.HasOne(ur => ur.Rol)
				.WithMany(r => r.UsuarioRoles)
				.HasForeignKey(ur => ur.IdRol);

			modelBuilder.Entity<UsuarioRol>()
				.HasOne(ur => ur.Usuario)
				.WithMany(u => u.UsuarioRoles)
				.HasForeignKey(ur => ur.IdUsuario);

			modelBuilder.Entity<Resumen>()
				.HasMany(x => x.Detalles)
				.WithOne(x => x.Resumen)
				.HasForeignKey(x => x.IdResumen);

			modelBuilder.Entity<ResumenDetalle>()
				.HasOne(x => x.Documento)
				.WithMany()
				.HasForeignKey(x => x.IdDocumento);

			modelBuilder.Entity<Resumen>()
				.Property(x => x.Estado)
				.HasDefaultValue(EstadoResumen.Generado)
				.HasConversion<int>();

			modelBuilder.Entity<ResumenDetalle>()
				.Property(x => x.Estado)
				.HasConversion<int>();


			modelBuilder.Entity<ComunicacionBaja>()
				.HasMany(x => x.Detalles)
				.WithOne(x => x.ComunicacionBaja)
				.HasForeignKey(x => x.IdBaja);

			modelBuilder.Entity<ComunicacionBajaDetalle>()
				.HasOne(x => x.Documento)
				.WithMany()
				.HasForeignKey(x => x.IdDocumento);

			modelBuilder.Entity<ComunicacionBaja>()
				.Property(x => x.Estado)
				.HasDefaultValue(EstadoResumen.Generado)
				.HasConversion<int>();

			modelBuilder.Entity<CitasResult>(entity =>
					entity.HasNoKey());

			modelBuilder.Entity<Documento>()
				.HasMany(x => x.Citas)
				.WithOne(x => x.Documento)
				.HasForeignKey(x => x.IdDocumento);

			modelBuilder.Entity<Producto>()
				.HasOne(x => x.UnidadMedida)
				.WithMany()
				.HasForeignKey(x => x.IdUnidadMedida);

			modelBuilder.Entity<Producto>()
				.HasOne(x => x.TipoAfectacionIgv)
				.WithMany()
				.HasForeignKey(x => x.IdTipoAfectacionIgv);
		}

		#region IDisposable Support
		public override void Dispose()
		{
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}
