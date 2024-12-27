using Autofac;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Repositorio.Contratos;
using HVLH.SistemaCaja.Repositorio.Impl;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace HVLH.SistemaCaja.Repositorio.IoC
{
	public class RepositorioModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			var options = new DbContextOptionsBuilder<SiheContexto>()
						 .UseSqlServer(ConfigurationManager.ConnectionStrings["SiheDB"].ConnectionString)
						 .Options;

			builder.Register(c => new SiheContexto(options)).As<ISiheContexto>();
		}
	}
}
