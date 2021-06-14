using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entitys
{
    public class ReservaLivro : Base
    {
        public int LivroID { get; set; }
        public int UsuarioID { get; set; }
        public bool Ativa { get; set; }
    }
}
