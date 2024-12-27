using Autofac;
using AutoMapper;
using HVLH.Facturacion.Firmas;
using HVLH.Facturacion.Servicio;
using HVLH.Facturacion.Servicio.Soap;
using HVLH.SistemaCaja.Repositorio.IoC;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.Impl;
using HVLH.SistemaCaja.Servicio.Mapper;
using IServicioSunat = HVLH.SistemaCaja.Servicio.Contratos.IServicioSunat;

namespace HVLH.SistemaCaja.Servicio.IoC
{
	public class ServicioModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.Register(context => new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<ServicioProfile>();
			})).AsSelf().SingleInstance();

			builder.Register(c =>
			{
				//This resolves a new context that can be used later.
				var context = c.Resolve<IComponentContext>();
				var config = context.Resolve<MapperConfiguration>();
				return config.CreateMapper(context.Resolve);
			})
		   .As<IMapper>()
		   .InstancePerLifetimeScope();

			builder.RegisterModule(new RepositorioModule());

			builder.RegisterType<ServicioTipoDocumento>().As<IServicioTipoDocumento>();
			builder.RegisterType<ServicioTipoDocumentoSerie>().As<IServicioTipoDocumentoSerie>();
			builder.RegisterType<ServicioPreventa>().As<IServicioPreventa>();
			builder.RegisterType<ServicioFacturacion>().As<IServicioFacturacion>();
			builder.RegisterType<ServicioConfiguracion>().As<IServicioConfiguracion>();
			builder.RegisterType<ServicioTipoOperacion>().As<IServicioTipoOperacion>();
			builder.RegisterType<ServicioTipoMedioPago>().As<IServicioTipoMedioPago>();
			builder.RegisterType<ServicioCatalogoServicio>().As<IServicioCatalogoServicio>();
			builder.RegisterType<ServicioImpresion>().As<IServicioImpresion>();
			builder.RegisterType<Serializador>().As<ISerializador>();
			builder.RegisterType<Certificador>().As<ICertificador>();
			builder.RegisterType<ServicioXml>().As<IServicioXml>();
			builder.RegisterType<ServicioDocumento>().As<IServicioDocumento>();
			builder.RegisterType<ServicioSunatDocumentos>().As<IServicioSunatDocumentos>();
			builder.RegisterType<ServicioSunatConsultas>().As<IServicioSunatConsultas>();
			builder.RegisterType<ServicioEnvioDocumento>().As<IServicioEnvioDocumento>();
			builder.RegisterType<ServicioReniec>().As<IServicioReniec>();
			builder.RegisterType<ServicioUsuario>().As<IServicioUsuario>();
			builder.RegisterType<ServicioRol>().As<IServicioRol>();
			builder.RegisterType<ServicioMenu>().As<IServicioMenu>();
			builder.RegisterType<ServicioAutenticacion>().As<IServicioAutenticacion>();
			builder.RegisterType<ServicioSunat>().As<IServicioSunat>();
			builder.RegisterType<ServicioPaciente>().As<IServicioPaciente>();
			builder.RegisterType<ServicioResumen>().As<IServicioResumen>();
			builder.RegisterType<ServicioComunicacionBaja>().As<IServicioComunicacionBaja>();
			builder.RegisterType<ServicioCita>().As<IServicioCita>();
			builder.RegisterType<ServicioProducto>().As<IServicioProducto>();
			builder.RegisterType<ServicioUnidadMedida>().As<IServicioUnidadMedida>();
			builder.RegisterType<ServicioTipoAfectacionIgv>().As<IServicioTipoAfectacionIgv>();
		}
	}
}
