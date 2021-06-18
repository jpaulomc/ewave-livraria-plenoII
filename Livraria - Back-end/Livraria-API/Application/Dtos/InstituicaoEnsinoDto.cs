namespace Application.Dtos
{
    public class InstituicaoEnsinoDto
    {
        public int Id { get; set; }
        public int EnderecoID { get; set; }
        public string Nome { get; set; }
        public EnderecoDto EnderecoDto { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
    }
}
