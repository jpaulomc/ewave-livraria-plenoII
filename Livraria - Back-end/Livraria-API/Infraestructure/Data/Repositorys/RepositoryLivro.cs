using Domain.Core.Interfaces.Repositorys;
using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<Livro> GetAll()
        {
            return _sqlContext.Set<Livro>().Include(l => l.Genero)
                .Include(b => b.Autor ).ToList();
        }
    }
}
