using Domain.Core.Interfaces.Repositorys;
using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<InstituicaoEnsino> GetAll()
        {
            return _sqlContext.Set<InstituicaoEnsino>().Include(i => i.Endereco).ToList();
        }
    }
}
