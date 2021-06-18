using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Mappers;
using Domain.Core.Interfaces.Services;
using System.Collections.Generic;

namespace Application
{
    public class ApplicationServiceUsuarioBloqueado : IApplicationServiceUsuarioBloqueado
    {
        private readonly IServiceUsuarioBloqueado _serviceUsuarioBloqueado;
        private readonly IMapperUsuarioBloqueado _mapperUsuarioBloqueado;

        public ApplicationServiceUsuarioBloqueado(IServiceUsuarioBloqueado serviceUsuarioBloqueado, IMapperUsuarioBloqueado mapperUsuarioBloqueado)
        {
            _serviceUsuarioBloqueado = serviceUsuarioBloqueado;
            _mapperUsuarioBloqueado = mapperUsuarioBloqueado;
        }

        public void Add(UsuarioBloqueadoDto usuarioBloqueadoDto)
        {
            var usuarioBloqueado = _mapperUsuarioBloqueado.MapperDtoToEntity(usuarioBloqueadoDto);
            _serviceUsuarioBloqueado.Add(usuarioBloqueado);
        }

        public IEnumerable<UsuarioBloqueadoDto> GetAll()
        {
            var usuarioBloqueados = _serviceUsuarioBloqueado.GetAll();
            return _mapperUsuarioBloqueado.MapperListUsuarioBloqueadosDto(usuarioBloqueados);
        }

        public UsuarioBloqueadoDto GetById(int id)
        {
            var usuarioBloqueado = _serviceUsuarioBloqueado.GetById(id);
            return _mapperUsuarioBloqueado.MapperEntityToDto(usuarioBloqueado);
        }

        public void Update(UsuarioBloqueadoDto usuarioBloqueadoDto)
        {
            var usuarioBloqueado = _mapperUsuarioBloqueado.MapperDtoToEntity(usuarioBloqueadoDto);
            _serviceUsuarioBloqueado.Update(usuarioBloqueado);
        }
    }
}
