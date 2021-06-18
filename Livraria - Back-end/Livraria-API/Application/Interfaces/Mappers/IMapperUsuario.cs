using Application.Dtos;
using Domain.Entitys;
using System.Collections.Generic;

namespace Application.Interfaces.Mappers
{
    public interface IMapperUsuario
    {
        Usuario MapperDtoToEntity(UsuarioDto usuarioDto);
        IEnumerable<UsuarioDto> MapperListUsuariosDto(IEnumerable<Usuario> usuarios);
        UsuarioDto MapperEntityToDto(Usuario usuario);
    }
}
