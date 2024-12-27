using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace HVLH.Facturacion.Servicio.Soap.Consultas
{
	[DebuggerStepThrough]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[MessageContract(IsWrapped = true, WrapperName = "getStatus", WrapperNamespace = "http://service.sunat.gob.pe")]
	public class getStatusRequest
	{
		[MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 0)]
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public string rucComprobante;
		[MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 1)]
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public string tipoComprobante;
		[MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 2)]
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public string serieComprobante;
		[MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 3)]
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public int numeroComprobante;

		public getStatusRequest()
		{
		}

		public getStatusRequest(
		  string rucComprobante,
		  string tipoComprobante,
		  string serieComprobante,
		  int numeroComprobante)
		{
			this.rucComprobante = rucComprobante;
			this.tipoComprobante = tipoComprobante;
			this.serieComprobante = serieComprobante;
			this.numeroComprobante = numeroComprobante;
		}
	}
}
