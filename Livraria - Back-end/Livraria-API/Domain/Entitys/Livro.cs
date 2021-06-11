namespace Domain.Entitys
{
    public class Livro : Base
    {
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Autor { get; set; }
        public string Sinopse { get; set; }
        public string Capa { get; set; }
        public bool Ativo { get; set; }
    }
}
