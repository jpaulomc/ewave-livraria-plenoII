namespace Domain.Entitys
{
    public class InstituicaoEnsino : Base
    {
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
    }
}
