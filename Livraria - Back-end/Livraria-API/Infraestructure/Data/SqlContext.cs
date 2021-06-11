using Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext() { }
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<InstituicaoEnsino> InstituicaoEnsino { get; set; }
        public DbSet<Livro> Livro { get; set; }

    }
}
