using System.CodeDom.Compiler;
using System.ServiceModel;

namespace HVLH.Facturacion.Servicio.Soap.Documentos
{
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[ServiceContract(ConfigurationName = "Documentos.billService", Namespace = "http://service.sunat.gob.pe")]
	public interface billService
	{
		[OperationContract(Action = "urn:getStatus", ReplyAction = "*")]
		[XmlSerializerFormat(SupportFaults = true)]
		[return: MessageParameter(Name = "status")]
		getStatusResponse getStatus(getStatusRequest request);

		[OperationContract(Action = "urn:sendBill", ReplyAction = "*")]
		[XmlSerializerFormat(SupportFaults = true)]
		[return: MessageParameter(Name = "applicationResponse")]
		sendBillResponse sendBill(sendBillRequest request);

		[OperationContract(Action = "urn:sendPack", ReplyAction = "*")]
		[XmlSerializerFormat(SupportFaults = true)]
		[return: MessageParameter(Name = "ticket")]
		sendPackResponse sendPack(sendPackRequest request);

		[OperationContract(Action = "urn:sendSummary", ReplyAction = "*")]
		[XmlSerializerFormat(SupportFaults = true)]
		[return: MessageParameter(Name = "ticket")]
		sendSummaryResponse sendSummary(sendSummaryRequest request);
	}
}
