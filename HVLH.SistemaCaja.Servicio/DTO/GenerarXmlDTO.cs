using HVLH.Facturacion.Comun.Datos.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class GenerarXmlDTO
	{
        public string CertificadoDigital { get; set; }
        public string PasswordCertificado { get; set; }
        public string Ruta { get; set; }
        public IDocumentoElectronico Documento { get; set; }
    }
}
