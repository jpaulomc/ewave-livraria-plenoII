using Domain.Core.Interfaces.Repositorys;
using Domain.Core.Interfaces.Services;
using Domain.Entitys;

namespace Domain.Services
{
    public class ServiceGenero : ServiceBase<Genero>, IServiceGenero
    {
        private readonly IRepositoryGenero _repositoryGenero;

        public ServiceGenero(IRepositoryGenero repositoryGenero) : base(repositoryGenero)
        {
            _repositoryGenero = repositoryGenero;
        }
    }
}
