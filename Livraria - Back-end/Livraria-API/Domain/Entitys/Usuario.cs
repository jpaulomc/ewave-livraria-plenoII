namespace Domain.Entitys
{
    public class Usuario : Base
    {

        public int EnderecoID { get; set; }
        public int InstituicaoEnsinoID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }

        public Endereco Endereco { get; set; }
        public InstituicaoEnsino InstituicaoEnsino { get; set; }
    }
}
