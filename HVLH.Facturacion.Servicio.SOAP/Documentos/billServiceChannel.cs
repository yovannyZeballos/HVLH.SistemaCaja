using System;
using System.CodeDom.Compiler;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace HVLH.Facturacion.Servicio.Soap.Documentos
{
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  public interface billServiceChannel : 
    billService,
    IClientChannel,
    IContextChannel,
    IChannel,
    ICommunicationObject,
    IExtensibleObject<IContextChannel>,
    IDisposable
  {
  }
}
