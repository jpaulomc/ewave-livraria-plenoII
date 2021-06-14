using System;

namespace Application.Dtos
{
    public class UsuarioBloqueadoDto
    {
        public int Id { get; set; }
        public DateTime DataBloqueio { get; set; }
        public DateTime DataLiberacao { get; set; }
        public bool StatusBloqueio { get; set; }
        public UsuarioDto UsuarioDto { get; set; }
        public EmprestimoLivroDto EmprestimoLivroDto { get; set; }
    }
}
