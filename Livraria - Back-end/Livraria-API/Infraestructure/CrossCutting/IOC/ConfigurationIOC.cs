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
            builder.RegisterType<ApplicationServiceAutor>().As<IApplicationServiceAutor>();
            builder.RegisterType<ApplicationServiceGenero>().As<IApplicationServiceGenero>();
            builder.RegisterType<ApplicationServiceEmprestimoLivro>().As<IApplicationServiceEmprestimoLivro>();
            builder.RegisterType<ApplicationServiceEndereco>().As<IApplicationServiceEndereco>();
            builder.RegisterType<ApplicationServiceReservaLivro>().As<IApplicationServiceReservaLivro>();
            builder.RegisterType<ApplicationServiceUsuarioBloqueado>().As<IApplicationServiceUsuarioBloqueado>();

            builder.RegisterType<ServiceUsuario>().As<IServiceUsuario>();
            builder.RegisterType<ServiceInstituicaoEnsino>().As<IServiceInstituicaoEnsino>();
            builder.RegisterType<ServiceLivro>().As<IServiceLivro>();
            builder.RegisterType<ServiceAutor>().As<IServiceAutor>();
            builder.RegisterType<ServiceGenero>().As<IServiceGenero>();
            builder.RegisterType<ServiceEmprestimoLivro>().As<IServiceEmprestimoLivro>();
            builder.RegisterType<ServiceEndereco>().As<IServiceEndereco>();
            builder.RegisterType<ServiceReservaLivro>().As<IServiceReservaLivro>();
            builder.RegisterType<ServiceUsuarioBloqueado>().As<IServiceUsuarioBloqueado>();

            builder.RegisterType<MapperEndereco>().As<IMapperEndereco>();
            builder.RegisterType<MapperUsuario>().As<IMapperUsuario>();
            builder.RegisterType<MapperInstituicaoEnsino>().As<IMapperInstituicaoEnsino>();
            builder.RegisterType<MapperLivro>().As<IMapperLivro>();
            builder.RegisterType<MapperAutor>().As<IMapperAutor>();
            builder.RegisterType<MapperEmprestimoLivro>().As<IMapperEmprestimoLivro>();
            builder.RegisterType<MapperGenero>().As<IMapperGenero>();
            builder.RegisterType<MapperReservaLivro>().As<IMapperReservaLivro>();
            builder.RegisterType<MapperUsuarioBloqueado>().As<IMapperUsuarioBloqueado>();

            builder.RegisterType<RepositoryUsuario>().As<IRepositoryUsuario>();
            builder.RegisterType<RepositoryInstituicaoEnsino>().As<IRepositoryInstituicaoEnsino>();
            builder.RegisterType<RepositoryLivro>().As<IRepositoryLivro>();
            builder.RegisterType<RepositoryAutor>().As<IRepositoryAutor>();
            builder.RegisterType<RepositoryEmprestimoLivro>().As<IRepositoryEmprestimoLivro>();
            builder.RegisterType<RepositoryEndereco>().As<IRepositoryEndereco>();
            builder.RegisterType<RepositoryGenero>().As<IRepositoryGenero>();
            builder.RegisterType<RepositoryReservaLivro>().As<IRepositoryReservaLivro>();
            builder.RegisterType<RepositoryUsuarioBloqueado>().As<IRepositoryUsuarioBloqueado>();
            #endregion
        }
    }
}
