using Application.Dtos;
using Domain.Entitys;
using System.Collections.Generic;

namespace Application.Interfaces.Mappers
{
    public interface IMapperUsuarioBloqueado
    {
        UsuarioBloqueado MapperDtoToEntity(UsuarioBloqueadoDto usuarioBloqueadoDto);
        IEnumerable<UsuarioBloqueadoDto> MapperListUsuarioBloqueadosDto(IEnumerable<UsuarioBloqueado> usuarioBloqueados);
        UsuarioBloqueadoDto MapperEntityToDto(UsuarioBloqueado usuarioBloqueado);
    }
}
