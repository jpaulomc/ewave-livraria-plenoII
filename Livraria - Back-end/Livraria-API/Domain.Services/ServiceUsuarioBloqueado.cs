using Domain.Core.Interfaces.Repositorys;
using Domain.Core.Interfaces.Services;
using Domain.Entitys;

namespace Domain.Services
{
    public class ServiceUsuarioBloqueado : ServiceBase<UsuarioBloqueado>, IServiceUsuarioBloqueado
    {
        private readonly IRepositoryUsuarioBloqueado _repositoryUsuarioBloqueado;

        public ServiceUsuarioBloqueado(IRepositoryUsuarioBloqueado repositoryUsuarioBloqueado) : base(repositoryUsuarioBloqueado)
        {
            _repositoryUsuarioBloqueado = repositoryUsuarioBloqueado;
        }
    }
}
