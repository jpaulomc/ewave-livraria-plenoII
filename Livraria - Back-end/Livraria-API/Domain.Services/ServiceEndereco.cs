using Domain.Core.Interfaces.Repositorys;
using Domain.Core.Interfaces.Services;
using Domain.Entitys;

namespace Domain.Services
{
    public class ServiceEndereco : ServiceBase<Endereco>, IServiceEndereco
    {
        private readonly IRepositoryEndereco _repositoryEndereco;

        public ServiceEndereco(IRepositoryEndereco repositoryEndereco) : base(repositoryEndereco)
        {
            _repositoryEndereco = repositoryEndereco;
        }
    }
}
