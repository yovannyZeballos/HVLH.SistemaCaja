﻿using System.CodeDom.Compiler;
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
	[MessageContract(IsWrapped = true, WrapperName = "sendBillResponse", WrapperNamespace = "http://service.sunat.gob.pe")]
	public class sendBillResponse
	{
		[MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 0)]
		[XmlElement(DataType = "base64Binary", Form = XmlSchemaForm.Unqualified)]
		public byte[] applicationResponse;

		public sendBillResponse()
		{
		}

		public sendBillResponse(byte[] applicationResponse) => this.applicationResponse = applicationResponse;
	}
}
