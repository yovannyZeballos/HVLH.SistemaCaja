using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace HVLH.Facturacion.Servicio.Soap.Documentos
{
	[DebuggerStepThrough]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[MessageContract(IsWrapped = true, WrapperName = "sendSummaryResponse", WrapperNamespace = "http://service.sunat.gob.pe")]
	public class sendSummaryResponse
	{
		[MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 0)]
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public string ticket;

		public sendSummaryResponse()
		{
		}

		public sendSummaryResponse(string ticket) => this.ticket = ticket;
	}
}
