namespace Domain.Entitys
{
    public enum StatusLivroEnum
    {
        Disponível = 1,
        Emprestado = 2,
        Reservado = 3
    }

    public class Livro : Base
    {
        public string Titulo { get; set; }
        public string GeneroID { get; set; }
        public string AutorID { get; set; }
        public string Sinopse { get; set; }
        public string Capa { get; set; }
        public bool Ativo { get; set; }
        public StatusLivroEnum StatusLivro { get; set; }

        public Genero Genero { get; set; }
        public Autor Autor {get;set;}

    }
}
