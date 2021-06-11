using Application.Dtos;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IApplicationServiceUsuario
    {
        void Add(UsuarioDto usuarioDto);
        void Update(UsuarioDto usuarioDto);
        IEnumerable<UsuarioDto> GetAll();
        UsuarioDto GetById(int id);
    }
}
