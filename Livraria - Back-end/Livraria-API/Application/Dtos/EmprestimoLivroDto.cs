using System;

namespace Application.Dtos
{
    public class EmprestimoLivroDto
    {
        public int Id { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataPrazoEntrega { get; set; }
        public DateTime DataEntrega { get; set; }

        public LivroDto Livro { get; set; }
        public UsuarioDto Usuario { get; set; }
    }
}
