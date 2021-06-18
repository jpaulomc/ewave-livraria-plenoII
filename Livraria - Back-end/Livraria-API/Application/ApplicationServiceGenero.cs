using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Mappers;
using Domain.Core.Interfaces.Services;
using System.Collections.Generic;

namespace Application
{
    public class ApplicationServiceGenero : IApplicationServiceGenero
    {
        private readonly IServiceGenero _serviceGenero;
        private readonly IMapperGenero _mapperGenero;
        public ApplicationServiceGenero(IServiceGenero serviceGenero, IMapperGenero mapperGenero)
        {
            _serviceGenero = serviceGenero;
            _mapperGenero = mapperGenero;
        }

        public void Add(GeneroDto generoDto)
        {
            var genero = _mapperGenero.MapperDtoToEntity(generoDto);
            _serviceGenero.Add(genero);
        }

        public IEnumerable<GeneroDto> GetAll()
        {
            var generos = _serviceGenero.GetAll();
            return _mapperGenero.MapperListGenerosDto(generos);
        }

        public GeneroDto GetById(int id)
        {
            var genero = _serviceGenero.GetById(id);
            return _mapperGenero.MapperEntityToDto(genero);
        }

        public void Update(GeneroDto generoDto)
        {
            var genero = _mapperGenero.MapperDtoToEntity(generoDto);
            _serviceGenero.Update(genero);
        }
    }
}
