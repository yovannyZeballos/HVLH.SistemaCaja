using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace HVLH.Facturacion.Servicio.Soap
{
	public class PasswordDigestBehavior : IEndpointBehavior
	{
		public string Usuario { get; set; }

		public string Password { get; set; }

		public PasswordDigestBehavior(string username, string password)
		{
			this.Usuario = username;
			this.Password = password;
		}

		public void AddBindingParameters(
		  ServiceEndpoint endpoint,
		  BindingParameterCollection bindingParameters)
		{
		}

		public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime) => clientRuntime.MessageInspectors.Add((IClientMessageInspector)new PasswordDigestMessageInspector(this.Usuario, this.Password));

		public void ApplyDispatchBehavior(
		  ServiceEndpoint endpoint,
		  EndpointDispatcher endpointDispatcher)
		{
		}

		public void Validate(ServiceEndpoint endpoint)
		{
		}
	}
}
