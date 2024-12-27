using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace HVLH.Facturacion.Servicio.Soap.Documentos
{
	[DebuggerStepThrough]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	public class billServiceClient : ClientBase<billService>, billService
	{
		public billServiceClient()
		{
		}

		public billServiceClient(string endpointConfigurationName)
		  : base(endpointConfigurationName)
		{
		}

		public billServiceClient(string endpointConfigurationName, string remoteAddress)
		  : base(endpointConfigurationName, remoteAddress)
		{
		}

		public billServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		  : base(endpointConfigurationName, remoteAddress)
		{
		}

		public billServiceClient(Binding binding, EndpointAddress remoteAddress)
		  : base(binding, remoteAddress)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		getStatusResponse billService.getStatus(getStatusRequest request) => this.Channel.getStatus(request);

		public statusResponse getStatus(string ticket) => ((billService)this).getStatus(new getStatusRequest()
		{
			ticket = ticket
		}).status;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		sendBillResponse billService.sendBill(sendBillRequest request) => this.Channel.sendBill(request);

		public byte[] sendBill(string fileName, byte[] contentFile, string partyType) => ((billService)this).sendBill(new sendBillRequest()
		{
			fileName = fileName,
			contentFile = contentFile,
			partyType = partyType
		}).applicationResponse;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		sendPackResponse billService.sendPack(sendPackRequest request) => this.Channel.sendPack(request);

		public string sendPack(string fileName, byte[] contentFile, string partyType) => ((billService)this).sendPack(new sendPackRequest()
		{
			fileName = fileName,
			contentFile = contentFile,
			partyType = partyType
		}).ticket;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		sendSummaryResponse billService.sendSummary(
		  sendSummaryRequest request)
		{
			return this.Channel.sendSummary(request);
		}

		public string sendSummary(string fileName, byte[] contentFile, string partyType) => ((billService)this).sendSummary(new sendSummaryRequest()
		{
			fileName = fileName,
			contentFile = contentFile,
			partyType = partyType
		}).ticket;
	}
}
