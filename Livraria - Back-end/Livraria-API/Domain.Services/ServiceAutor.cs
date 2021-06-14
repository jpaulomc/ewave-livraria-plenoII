using Domain.Core.Interfaces.Repositorys;
using Domain.Core.Interfaces.Services;
using Domain.Entitys;

namespace Domain.Services
{
    public class ServiceAutor : ServiceBase<Autor>, IServiceAutor
    {
        private readonly IRepositoryAutor _repositoryAutor;

        public ServiceAutor(IRepositoryAutor repositoryAutor) : base(repositoryAutor)
        {
            _repositoryAutor = repositoryAutor;
        }
    }
}
