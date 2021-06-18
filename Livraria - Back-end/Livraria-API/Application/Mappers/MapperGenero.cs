using Application.Dtos;
using Application.Interfaces.Mappers;
using Domain.Entitys;
using System.Collections.Generic;
using System.Linq;

namespace Application.Mappers
{
    public class MapperGenero : IMapperGenero
    {
        public Genero MapperDtoToEntity(GeneroDto generoDto)
        {
            var genero = new Genero()
            {
                Id = generoDto.Id,
                Descricao = generoDto.Descricao
            };

            return genero;
        }

        public GeneroDto MapperEntityToDto(Genero genero)
        {
            var generoDto = new GeneroDto()
            {
                Id = genero.Id,
                Descricao = genero.Descricao
            };

            return generoDto;
        }

        public IEnumerable<GeneroDto> MapperListGenerosDto(IEnumerable<Genero> genero)
        {
            var generos = genero.Select(g => new GeneroDto()
            {
                Id = g.Id,
                Descricao = g.Descricao
            });

            return generos;
        }
    }
}
