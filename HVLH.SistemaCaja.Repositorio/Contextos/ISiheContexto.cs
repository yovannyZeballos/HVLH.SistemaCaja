using HVLH.SistemaCaja.Repositorio.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Contextos
{
	public interface ISiheContexto : IDisposable
	{
        IRepositorioConfiguracion RepositorioConfiguracion { get;  }
        IRepositorioCorrelativoSerie RepositorioCorrelativoSerie { get; }
		IRepositorioDocumento RepositorioDocumento { get; }
		IRepositorioPreventa RepositorioPreventa { get; }
		IRepositorioTipoDocumento RepositorioTipoDocumento { get; }
		IRepositorioTipoDocumentoSerie RepositorioTipoDocumentoSerie { get; }
		IRepositorioTipoMedioPago RepositorioTipoMedioPago { get; }
		IRepositorioTipoOperacion RepositorioTipoOperacion { get; }
		IRepositorioCatalagoServicio RepositorioCatalagoServicio { get; }
		IRepositorioUsuario RepositorioUsuario { get; }
		IRepositorioRol RepositorioRol { get; }
		IRepositorioMenu RepositorioMenu { get; }
		IRepositorioPaciente RepositorioPaciente { get; }
		IRepositorioResumen RepositorioResumen { get; }
		IRepositorioComunicacionBaja RepositorioComunicacionBaja { get; }
		IRepositorioCita RepositorioCita { get; }
		IRepositorioDocumentoCita RepositorioDocumentoCita { get; }
		IRepositorioProducto RepositorioProducto { get; }
		IRepositorioTipoAfectacionIgv RepositorioTipoAfectacionIgv { get; }
		IRepositorioUnidadMedida RepositorioUnidadMedida { get; }
		IRepositorioDocumentoDetalle RepositorioDocumentoDetalle { get; }
		IRepositorioCuota RepositorioCuota { get; }
		IRepositorioMedioPagoDocumento RepositorioMedioPagoDocumento { get; }

		bool Commit();
		Task<bool> CommitAsync();
		void RefreshAll();
	}
}
