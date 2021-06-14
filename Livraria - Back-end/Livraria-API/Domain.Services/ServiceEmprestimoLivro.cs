using Domain.Core.Interfaces.Repositorys;
using Domain.Core.Interfaces.Services;
using Domain.Entitys;

namespace Domain.Services
{
    public class ServiceEmprestimoLivro : ServiceBase<EmprestimoLivro>, IServiceEmprestimoLivro
    {
        private readonly IRepositoryEmprestimoLivro _repositoryEmprestimoLivro;

        public ServiceEmprestimoLivro(IRepositoryEmprestimoLivro repositoryEmprestimoLivro) : base(repositoryEmprestimoLivro)
        {
            _repositoryEmprestimoLivro = repositoryEmprestimoLivro;
        }
    }
}
