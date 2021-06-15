using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Mappers;
using Domain.Core.Interfaces.Services;
using System.Collections.Generic;

namespace Application
{
    public class ApplicationServiceAutor : IApplicationServiceAutor
    {
        private readonly IServiceAutor _serviceAutor;
        private readonly IMapperAutor _mapperAutor;

        public ApplicationServiceAutor(IServiceAutor serviceAutor, IMapperAutor mapperAutor)
        {
            _serviceAutor = serviceAutor;
            _mapperAutor = mapperAutor;
        }
        public void Add(AutorDto autorDto)
        {
            var autor = _mapperAutor.MapperDtoToEntity(autorDto);
            _serviceAutor.Add(autor);
        }

        public IEnumerable<AutorDto> GetAll()
        {
            var listAutor = _serviceAutor.GetAll();
            return _mapperAutor.MapperListAutorDto(listAutor);
        }

        public AutorDto GetById(int id)
        {
            var autor = _serviceAutor.GetById(id);
            return _mapperAutor.MapperEntityToDto(autor);
        }

        public void Update(AutorDto autorDto)
        {
            var autor = _mapperAutor.MapperDtoToEntity(autorDto);
            _serviceAutor.Update(autor);
        }
    }
}
