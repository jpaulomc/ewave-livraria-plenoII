using Domain.Core.Interfaces.Repositorys;
using Domain.Entitys;

namespace Infraestructure.Data.Repositorys
{
    public class RepositoryAutor : RepositoryBase<Autor>, IRepositoryAutor
    {
        private readonly SqlContext _sqlContext;

        public RepositoryAutor(SqlContext sqlContext)
            : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}
