using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace HVLH.Facturacion.Servicio.Soap.Consultas
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
		getStatusCdrResponse billService.getStatusCdr(
		  getStatusCdrRequest request)
		{
			return this.Channel.getStatusCdr(request);
		}

		public statusResponse getStatusCdr(
		  string rucComprobante,
		  string tipoComprobante,
		  string serieComprobante,
		  int numeroComprobante)
		{
			return ((billService)this).getStatusCdr(new getStatusCdrRequest()
			{
				rucComprobante = rucComprobante,
				tipoComprobante = tipoComprobante,
				serieComprobante = serieComprobante,
				numeroComprobante = numeroComprobante
			}).statusCdr;
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		getStatusResponse billService.getStatus(getStatusRequest request) => this.Channel.getStatus(request);

		public statusResponse getStatus(
		  string rucComprobante,
		  string tipoComprobante,
		  string serieComprobante,
		  int numeroComprobante)
		{
			return ((billService)this).getStatus(new getStatusRequest()
			{
				rucComprobante = rucComprobante,
				tipoComprobante = tipoComprobante,
				serieComprobante = serieComprobante,
				numeroComprobante = numeroComprobante
			}).status;
		}
	}
}
