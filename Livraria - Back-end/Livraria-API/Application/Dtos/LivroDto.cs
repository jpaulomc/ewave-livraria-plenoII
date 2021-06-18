using Domain.Entitys;

namespace Application.Dtos
{
    public class LivroDto
    {
        public int Id { get; set; }
        public int GeneroID { get; set; }
        public string? GeneroDescricao { get; set; }
        public int AutorID { get; set; }
        public string? AutorNome { get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public string Capa { get; set; }
        public bool Ativo { get; set; }
        public StatusLivroEnum StatusLivro { get; set; }
        
    }
}
