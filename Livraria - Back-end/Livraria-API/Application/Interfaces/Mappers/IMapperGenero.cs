using Application.Dtos;
using Domain.Entitys;
using System.Collections.Generic;

namespace Application.Interfaces.Mappers
{
    public interface IMapperGenero
    {
        Genero MapperDtoToEntity(GeneroDto generoDto);
        IEnumerable<GeneroDto> MapperListGenerosDto(IEnumerable<Genero> genero);
        GeneroDto MapperEntityToDto(Genero genero);
    }
}
