using Autofac;
using HVLH.SistemaCaja.Servicio.IoC;

namespace HVLH.SistemaCaja.AppWin.IoC
{
	public class InstanceFactory
	{
		public static T GetInstance<T>()
		{
			var builder = new ContainerBuilder();
			builder.RegisterModule(new ServicioModule());
			IContainer Container = builder.Build();
			using (var scope = Container.BeginLifetimeScope())
			{
				return scope.Resolve<T>();
			}
		}
	}
}
