using System;

namespace Domain.Entitys
{
    public class EmprestimoLivro : Base
    {
        public int LivroID { get; set; }
        public int UsuarioID { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataPrazoEntrega { get; set; }
        public DateTime DataEntrega { get; set; }

        public Livro Livro { get; set; }
        public Usuario Usuario { get; set; }


    }
}
