using Application;
using Application.Interfaces;
using Application.Interfaces.Mappers;
using Application.Mappers;
using Autofac;
using Domain.Core.Interfaces.Repositorys;
using Domain.Core.Interfaces.Services;
using Domain.Services;
using Infraestructure.Data.Repositorys;

namespace Infraestructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.RegisterType<ApplicationServiceUsuario>().As<IApplicationServiceUsuario>();
            builder.RegisterType<ApplicationServiceInstituicaoEnsino>().As<IApplicationServiceInstituicaoEnsino>();
            builder.RegisterType<ApplicationServiceLivro>().As<IApplicationServiceLivro>();

            builder.RegisterType<ServiceUsuario>().As<IServiceUsuario>();
            builder.RegisterType<ServiceInstituicaoEnsino>().As<IServiceInstituicaoEnsino>();
            builder.RegisterType<ServiceLivro>().As<IServiceLivro>();

            builder.RegisterType<MapperEndereco>().As<IMapperEndereco>();
            builder.RegisterType<MapperUsuario>().As<IMapperUsuario>();
            builder.RegisterType<MapperInstituicaoEnsino>().As<IMapperInstituicaoEnsino>();
            builder.RegisterType<MapperLivro>().As<IMapperLivro>();

            builder.RegisterType<RepositoryUsuario>().As<IRepositoryUsuario>();
            builder.RegisterType<RepositoryInstituicaoEnsino>().As<IRepositoryInstituicaoEnsino>();
            builder.RegisterType<RepositoryLivro>().As<IRepositoryLivro>();
            #endregion
        }
    }
}
