using Domain.Core.Interfaces.Repositorys;
using Domain.Entitys;

namespace Infraestructure.Data.Repositorys
{
    public class RepositoryInstituicaoEnsino : RepositoryBase<InstituicaoEnsino>, IRepositoryInstituicaoEnsino
    {
        private readonly SqlContext _sqlContext;

        public RepositoryInstituicaoEnsino(SqlContext sqlContext)
            : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}
