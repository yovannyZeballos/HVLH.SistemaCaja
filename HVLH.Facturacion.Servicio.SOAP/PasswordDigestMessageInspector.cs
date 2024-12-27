using Microsoft.Web.Services3.Security.Tokens;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Xml;

namespace HVLH.Facturacion.Servicio.Soap
{
	public class PasswordDigestMessageInspector : IClientMessageInspector
	{
		public string Username { get; set; }

		public string Password { get; set; }

		public PasswordDigestMessageInspector(string username, string password)
		{
			this.Username = username;
			this.Password = password;
		}

		public void AfterReceiveReply(ref Message reply, object correlationState)
		{
		}

		public object BeforeSendRequest(ref Message request, IClientChannel channel)
		{
			XmlElement xml = new UsernameToken(this.Username, this.Password, PasswordOption.SendPlainText).GetXml(new XmlDocument());
			xml.GetElementsByTagName("wsse:Nonce").Item(0)?.RemoveAll();
			MessageHeader header = MessageHeader.CreateHeader("Security", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd", (object)xml, false);
			request.Headers.Add(header);
			return Convert.DBNull;
		}
	}
}
