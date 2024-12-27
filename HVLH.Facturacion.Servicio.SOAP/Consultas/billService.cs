using System.CodeDom.Compiler;
using System.ServiceModel;

namespace HVLH.Facturacion.Servicio.Soap.Consultas
{
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[ServiceContract(ConfigurationName = "Consultas.billService", Namespace = "http://service.sunat.gob.pe")]
	public interface billService
	{
		[OperationContract(Action = "urn:getStatusCdr", ReplyAction = "http://service.sunat.gob.pe/billService/getStatusCdrResponse")]
		[XmlSerializerFormat(SupportFaults = true)]
		[return: MessageParameter(Name = "statusCdr")]
		getStatusCdrResponse getStatusCdr(getStatusCdrRequest request);

		[OperationContract(Action = "urn:getStatus", ReplyAction = "http://service.sunat.gob.pe/billService/getStatusResponse")]
		[XmlSerializerFormat(SupportFaults = true)]
		[return: MessageParameter(Name = "status")]
		getStatusResponse getStatus(getStatusRequest request);
	}
}
