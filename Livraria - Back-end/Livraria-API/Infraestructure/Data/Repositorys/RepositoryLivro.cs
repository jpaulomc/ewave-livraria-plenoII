using Domain.Core.Interfaces.Repositorys;
using Domain.Entitys;

namespace Infraestructure.Data.Repositorys
{
    public class RepositoryLivro : RepositoryBase<Livro>, IRepositoryLivro
    {
        private readonly SqlContext _sqlContext;

        public RepositoryLivro(SqlContext sqlContext)
            : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}
