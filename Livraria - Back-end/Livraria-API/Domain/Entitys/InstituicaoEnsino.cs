﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entitys
{
    public class InstituicaoEnsino : Base
    {
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public string CPNJ { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
    }
}
