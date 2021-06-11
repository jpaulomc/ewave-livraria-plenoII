using Domain.Core.Interfaces.Repositorys;
using Domain.Entitys;

namespace Infraestructure.Data.Repositorys
{
    public class RepositoryUsuario : RepositoryBase<Usuario>, IRepositoryUsuario
    {
        private readonly SqlContext _sqlContext;

        public RepositoryUsuario(SqlContext sqlContext) 
            :base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}
