namespace Application.Dtos
{
    public class InstituicaoEnsinoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public EnderecoDto Endereco { get; set; }
        public string CPNJ { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
    }
}
