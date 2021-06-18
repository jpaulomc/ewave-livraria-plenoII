namespace Domain.Entitys
{
    public class ReservaLivro : Base
    {
        public int LivroID { get; set; }
        public int UsuarioID { get; set; }
        public bool Ativa { get; set; }

        public Livro Livro { get; set; }
        public Usuario Usuario { get; set; }

    }
}
