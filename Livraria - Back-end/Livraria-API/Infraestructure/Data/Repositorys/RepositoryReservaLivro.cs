using Domain.Core.Interfaces.Repositorys;
using Domain.Entitys;

namespace Infraestructure.Data.Repositorys
{
    public class RepositoryReservaLivro : RepositoryBase<ReservaLivro>, IRepositoryReservaLivro
    {
        private readonly SqlContext _sqlContext;

        public RepositoryReservaLivro(SqlContext sqlContext)
            : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}
