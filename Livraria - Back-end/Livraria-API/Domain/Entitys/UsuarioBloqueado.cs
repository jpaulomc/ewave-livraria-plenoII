using System;

namespace Domain.Entitys
{
    public class UsuarioBloqueado : Base
    {
        public int UsuarioID { get; set; }
        public int EmprestimoLivroID { get; set; }
        public DateTime DataBloqueio { get; set; }
        public DateTime DataLiberacao { get; set; }
        public bool StatusBloqueio { get; set; }

        public Usuario Usuario { get; set; }
        public EmprestimoLivro EmprestimoLivro { get; set; }
    }
}
