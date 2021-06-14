using Domain.Core.Interfaces.Repositorys;
using Domain.Core.Interfaces.Services;
using Domain.Entitys;

namespace Domain.Services
{
    public class ServiceReservaLivro : ServiceBase<ReservaLivro>, IServiceReservaLivro
    {
        private readonly IRepositoryReservaLivro _repositoryReservaLivro;

        public ServiceReservaLivro(IRepositoryReservaLivro repositoryReservaLivro) : base(repositoryReservaLivro)
        {
            _repositoryReservaLivro = repositoryReservaLivro;
        }
    }
}
