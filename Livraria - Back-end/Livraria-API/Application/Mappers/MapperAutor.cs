using Application.Dtos;
using Application.Interfaces.Mappers;
using Domain.Entitys;
using System.Collections.Generic;
using System.Linq;

namespace Application.Mappers
{
    public class MapperAutor : IMapperAutor
    {
        public Autor MapperDtoToEntity(AutorDto autorDto)
        {
            var autor = new Autor()
            {
                Id = autorDto.Id,
                Nome = autorDto.Nome
            };

            return autor;
        }

        public AutorDto MapperEntityToDto(Autor autor)
        {
            var autorDto = new AutorDto()
            {
                Id = autor.Id,
                Nome = autor.Nome
            };

            return autorDto;
        }

        public IEnumerable<AutorDto> MapperListAutorDto(IEnumerable<Autor> autor)
        {
            var listAutor = autor.Select(a => new AutorDto()
            {
                Id = a.Id,
                Nome = a.Nome
            });

            return listAutor;
        }
    }
}
