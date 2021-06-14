namespace Application.Dtos
{
    public class ReservaLivroDto
    {
        public int Id { get; set; }
        public bool Ativa { get; set; }
        public LivroDto LivroDto { get; set; }
        public UsuarioDto UsuarioDto { get; set; }
    }
}
