namespace Application.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public EnderecoDto EnderecoDto { get; set; }
        public string CPF { get; set; }
        public InstituicaoEnsinoDto InstituicaoEnsinoDto { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
    }
}
