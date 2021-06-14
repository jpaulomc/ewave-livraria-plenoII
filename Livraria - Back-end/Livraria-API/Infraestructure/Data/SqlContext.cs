using Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext() { }
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<InstituicaoEnsino> InstituicaoEnsino { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<EmprestimoLivro> EmprestimoLivro { get; set; }
        public DbSet<ReservaLivro> ReservaLivro { get; set; }
        public DbSet<UsuarioBloqueado> UsuarioBloqueado { get; set; }


    }
}
