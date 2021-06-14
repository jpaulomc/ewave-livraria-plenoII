using Domain.Core.Interfaces.Repositorys;
using Domain.Entitys;

namespace Infraestructure.Data.Repositorys
{
    public class RepositoryUsuarioBloqueado : RepositoryBase<UsuarioBloqueado>, IRepositoryUsuarioBloqueado
    {
        private readonly SqlContext _sqlContext;

        public RepositoryUsuarioBloqueado(SqlContext sqlContext)
            : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}
