﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HVLH.SistemaCaja.Servicio.SWReniec {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SWReniec.serviciomqSoap")]
    public interface serviciomqSoap {
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el mensaje obtenerDatosBasicosRequest tiene encabezados.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/obtenerDatosBasicos", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosBasicosResponse obtenerDatosBasicos(HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosBasicosRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/obtenerDatosBasicos", ReplyAction="*")]
        System.Threading.Tasks.Task<HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosBasicosResponse> obtenerDatosBasicosAsync(HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosBasicosRequest request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el mensaje obtenerDatosCompletosRequest tiene encabezados.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/obtenerDatosCompletos", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosCompletosResponse obtenerDatosCompletos(HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosCompletosRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/obtenerDatosCompletos", ReplyAction="*")]
        System.Threading.Tasks.Task<HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosCompletosResponse> obtenerDatosCompletosAsync(HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosCompletosRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9037.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Credencialmq : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string appField;
        
        private string usuarioField;
        
        private string claveField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string app {
            get {
                return this.appField;
            }
            set {
                this.appField = value;
                this.RaisePropertyChanged("app");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string usuario {
            get {
                return this.usuarioField;
            }
            set {
                this.usuarioField = value;
                this.RaisePropertyChanged("usuario");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string clave {
            get {
                return this.claveField;
            }
            set {
                this.claveField = value;
                this.RaisePropertyChanged("clave");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr {
            get {
                return this.anyAttrField;
            }
            set {
                this.anyAttrField = value;
                this.RaisePropertyChanged("AnyAttr");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="obtenerDatosBasicos", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class obtenerDatosBasicosRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public HVLH.SistemaCaja.Servicio.SWReniec.Credencialmq Credencialmq;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string nrodoc;
        
        public obtenerDatosBasicosRequest() {
        }
        
        public obtenerDatosBasicosRequest(HVLH.SistemaCaja.Servicio.SWReniec.Credencialmq Credencialmq, string nrodoc) {
            this.Credencialmq = Credencialmq;
            this.nrodoc = nrodoc;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="obtenerDatosBasicosResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class obtenerDatosBasicosResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string[] obtenerDatosBasicosResult;
        
        public obtenerDatosBasicosResponse() {
        }
        
        public obtenerDatosBasicosResponse(string[] obtenerDatosBasicosResult) {
            this.obtenerDatosBasicosResult = obtenerDatosBasicosResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="obtenerDatosCompletos", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class obtenerDatosCompletosRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public HVLH.SistemaCaja.Servicio.SWReniec.Credencialmq Credencialmq;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string nrodoc;
        
        public obtenerDatosCompletosRequest() {
        }
        
        public obtenerDatosCompletosRequest(HVLH.SistemaCaja.Servicio.SWReniec.Credencialmq Credencialmq, string nrodoc) {
            this.Credencialmq = Credencialmq;
            this.nrodoc = nrodoc;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="obtenerDatosCompletosResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class obtenerDatosCompletosResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string[] obtenerDatosCompletosResult;
        
        public obtenerDatosCompletosResponse() {
        }
        
        public obtenerDatosCompletosResponse(string[] obtenerDatosCompletosResult) {
            this.obtenerDatosCompletosResult = obtenerDatosCompletosResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface serviciomqSoapChannel : HVLH.SistemaCaja.Servicio.SWReniec.serviciomqSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class serviciomqSoapClient : System.ServiceModel.ClientBase<HVLH.SistemaCaja.Servicio.SWReniec.serviciomqSoap>, HVLH.SistemaCaja.Servicio.SWReniec.serviciomqSoap {
        
        public serviciomqSoapClient() {
        }
        
        public serviciomqSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public serviciomqSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public serviciomqSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public serviciomqSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosBasicosResponse HVLH.SistemaCaja.Servicio.SWReniec.serviciomqSoap.obtenerDatosBasicos(HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosBasicosRequest request) {
            return base.Channel.obtenerDatosBasicos(request);
        }
        
        public string[] obtenerDatosBasicos(HVLH.SistemaCaja.Servicio.SWReniec.Credencialmq Credencialmq, string nrodoc) {
            HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosBasicosRequest inValue = new HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosBasicosRequest();
            inValue.Credencialmq = Credencialmq;
            inValue.nrodoc = nrodoc;
            HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosBasicosResponse retVal = ((HVLH.SistemaCaja.Servicio.SWReniec.serviciomqSoap)(this)).obtenerDatosBasicos(inValue);
            return retVal.obtenerDatosBasicosResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosBasicosResponse> HVLH.SistemaCaja.Servicio.SWReniec.serviciomqSoap.obtenerDatosBasicosAsync(HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosBasicosRequest request) {
            return base.Channel.obtenerDatosBasicosAsync(request);
        }
        
        public System.Threading.Tasks.Task<HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosBasicosResponse> obtenerDatosBasicosAsync(HVLH.SistemaCaja.Servicio.SWReniec.Credencialmq Credencialmq, string nrodoc) {
            HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosBasicosRequest inValue = new HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosBasicosRequest();
            inValue.Credencialmq = Credencialmq;
            inValue.nrodoc = nrodoc;
            return ((HVLH.SistemaCaja.Servicio.SWReniec.serviciomqSoap)(this)).obtenerDatosBasicosAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosCompletosResponse HVLH.SistemaCaja.Servicio.SWReniec.serviciomqSoap.obtenerDatosCompletos(HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosCompletosRequest request) {
            return base.Channel.obtenerDatosCompletos(request);
        }
        
        public string[] obtenerDatosCompletos(HVLH.SistemaCaja.Servicio.SWReniec.Credencialmq Credencialmq, string nrodoc) {
            HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosCompletosRequest inValue = new HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosCompletosRequest();
            inValue.Credencialmq = Credencialmq;
            inValue.nrodoc = nrodoc;
            HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosCompletosResponse retVal = ((HVLH.SistemaCaja.Servicio.SWReniec.serviciomqSoap)(this)).obtenerDatosCompletos(inValue);
            return retVal.obtenerDatosCompletosResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosCompletosResponse> HVLH.SistemaCaja.Servicio.SWReniec.serviciomqSoap.obtenerDatosCompletosAsync(HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosCompletosRequest request) {
            return base.Channel.obtenerDatosCompletosAsync(request);
        }
        
        public System.Threading.Tasks.Task<HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosCompletosResponse> obtenerDatosCompletosAsync(HVLH.SistemaCaja.Servicio.SWReniec.Credencialmq Credencialmq, string nrodoc) {
            HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosCompletosRequest inValue = new HVLH.SistemaCaja.Servicio.SWReniec.obtenerDatosCompletosRequest();
            inValue.Credencialmq = Credencialmq;
            inValue.nrodoc = nrodoc;
            return ((HVLH.SistemaCaja.Servicio.SWReniec.serviciomqSoap)(this)).obtenerDatosCompletosAsync(inValue);
        }
    }
}
