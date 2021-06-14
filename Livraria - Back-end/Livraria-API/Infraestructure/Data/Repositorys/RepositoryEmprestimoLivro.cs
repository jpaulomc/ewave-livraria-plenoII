using Domain.Core.Interfaces.Repositorys;
using Domain.Entitys;

namespace Infraestructure.Data.Repositorys
{
    public class RepositoryEmprestimoLivro : RepositoryBase<EmprestimoLivro>, IRepositoryEmprestimoLivro
    {
        private readonly SqlContext _sqlContext;

        public RepositoryEmprestimoLivro(SqlContext sqlContext)
            : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}
