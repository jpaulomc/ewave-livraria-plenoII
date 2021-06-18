using System;

namespace Application.Dtos
{
    public class EmprestimoLivroDto
    {
        public int Id { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataPrazoEntrega { get; set; }
        public DateTime DataEntrega { get; set; }

        public LivroDto LivroDto { get; set; }
        public UsuarioDto UsuarioDto { get; set; }
    }
}
