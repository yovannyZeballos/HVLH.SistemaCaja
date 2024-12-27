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
	[MessageContract(IsWrapped = true, WrapperName = "sendBill", WrapperNamespace = "http://service.sunat.gob.pe")]
	public class sendBillRequest
	{
		[MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 0)]
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public string fileName;
		[MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 1)]
		[XmlElement(DataType = "base64Binary", Form = XmlSchemaForm.Unqualified)]
		public byte[] contentFile;
		[MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 2)]
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public string partyType;

		public sendBillRequest()
		{
		}

		public sendBillRequest(string fileName, byte[] contentFile, string partyType)
		{
			this.fileName = fileName;
			this.contentFile = contentFile;
			this.partyType = partyType;
		}
	}
}
