﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public EnderecoDto Endereco { get; set; }
        public string CPF { get; set; }
        public InstituicaoEnsinoDto InstituicaoEnsino { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
    }
}
