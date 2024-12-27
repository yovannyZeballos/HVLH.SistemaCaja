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
	[MessageContract(IsWrapped = true, WrapperName = "getStatusCdrResponse", WrapperNamespace = "http://service.sunat.gob.pe")]
	public class getStatusCdrResponse
	{
		[MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 0)]
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public statusResponse statusCdr;

		public getStatusCdrResponse()
		{
		}

		public getStatusCdrResponse(statusResponse statusCdr) => this.statusCdr = statusCdr;
	}
}
