using Domain.Core.Interfaces.Repositorys;
using Domain.Core.Interfaces.Services;
using Domain.Entitys;

namespace Domain.Services
{
    public class ServiceLivro : ServiceBase<Livro>, IServiceLivro
    {
        private readonly IRepositoryLivro _repositoryLivro;

        public ServiceLivro(IRepositoryLivro repositoryLivro) : base(repositoryLivro)
        {
            _repositoryLivro = repositoryLivro;
        }
    }
}
