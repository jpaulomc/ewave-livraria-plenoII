using Domain.Core.Interfaces.Repositorys;
using Domain.Entitys;

namespace Infraestructure.Data.Repositorys
{
    public class RepositoryGenero : RepositoryBase<Genero>, IRepositoryGenero
    {
        private readonly SqlContext _sqlContext;

        public RepositoryGenero(SqlContext sqlContext)
            : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}
