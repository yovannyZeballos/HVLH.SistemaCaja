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
	[MessageContract(IsWrapped = true, WrapperName = "getStatus", WrapperNamespace = "http://service.sunat.gob.pe")]
	public class getStatusRequest
	{
		[MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 0)]
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public string ticket;

		public getStatusRequest()
		{
		}

		public getStatusRequest(string ticket) => this.ticket = ticket;
	}
}
