using Domain.Core.Interfaces.Repositorys;
using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<Usuario> GetAll()
        {
            return _sqlContext.Set<Usuario>().Include(e => e.Endereco)
                .Include(i => i.InstituicaoEnsino).ToList();
        }
    }
}
