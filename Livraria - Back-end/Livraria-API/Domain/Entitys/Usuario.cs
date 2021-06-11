using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entitys
{
    public class Usuario : Base
    {
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public string CPF { get; set; }
        public InstituicaoEnsino InstituicaoEnsino { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
    }
}
