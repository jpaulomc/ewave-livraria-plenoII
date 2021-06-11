using Domain.Core.Interfaces.Repositorys;
using Domain.Core.Interfaces.Services;
using Domain.Entitys;

namespace Domain.Services
{
    public class ServiceInstituicaoEnsino : ServiceBase<InstituicaoEnsino>, IServiceInstituicaoEnsino
    {
        private readonly IRepositoryInstituicaoEnsino _repositoryInstituicaoEnsino;

        public ServiceInstituicaoEnsino(IRepositoryInstituicaoEnsino repositoryInstituicaoEnsino) : base(repositoryInstituicaoEnsino)
        {
            _repositoryInstituicaoEnsino = repositoryInstituicaoEnsino;
        }
    }
}
