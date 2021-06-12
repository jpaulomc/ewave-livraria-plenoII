using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Mappers;
using Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Application
{
    public class ApplicationServiceUsuario : IApplicationServiceUsuario
    {
        private readonly IServiceUsuario _serviceUsuario;
        private readonly IMapperUsuario _mapperUsuario;

        public ApplicationServiceUsuario(IServiceUsuario serviceUsuario, IMapperUsuario mapperUsuario)
        {
            _serviceUsuario = serviceUsuario;
            _mapperUsuario = mapperUsuario;
        }

        public void Add(UsuarioDto usuarioDto)
        {
            var usuario = _mapperUsuario.MapperDtoToEntity(usuarioDto);
            _serviceUsuario.Add(usuario);
        }

        public IEnumerable<UsuarioDto> GetAll()
        {
            var usuarios = _serviceUsuario.GetAll();
            return _mapperUsuario.MapperListUsuariosDto(usuarios);
        }

        public UsuarioDto GetById(int id)
        {
            var usuario = _serviceUsuario.GetById(id);
            return _mapperUsuario.MapperEntityToDto(usuario);
        }

        public void Update(UsuarioDto usuarioDto)
        {
            var usuario = _mapperUsuario.MapperDtoToEntity(usuarioDto);
            _serviceUsuario.Update(usuario);
        }
    }
}
