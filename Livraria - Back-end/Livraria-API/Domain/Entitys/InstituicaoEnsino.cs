namespace Domain.Entitys
{
    public class InstituicaoEnsino : Base
    {
        public int EnderecoID { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }

        public Endereco Endereco { get; set; }
    }
}
