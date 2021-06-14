using Application.Dtos;
using Domain.Entitys;
using System.Collections.Generic;

namespace Application.Interfaces.Mappers
{
    public interface IMapperAutor
    {
        Autor MapperDtoToEntity(AutorDto autorDto);
        IEnumerable<AutorDto> MapperListAutorDto(IEnumerable<Autor> autor);
        AutorDto MapperEntityToDto(Autor autor);
    }
}
