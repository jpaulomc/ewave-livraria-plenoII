using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Mappers;
using Domain.Core.Interfaces.Services;
using System.Collections.Generic;

namespace Application
{
    public class ApplicationServiceUsuario : IApplicationServiceUsuario
    {
        private readonly IServiceUsuario _serviceUsuario;
        private readonly IMapperUsuario _mapperUsuario;
        private readonly IServiceEndereco _serviceEndereco;
        private readonly IServiceInstituicaoEnsino _serviceInstituicaoEnsino;

        public ApplicationServiceUsuario(IServiceUsuario serviceUsuario, IMapperUsuario mapperUsuario,
            IServiceEndereco serviceEndereco, IServiceInstituicaoEnsino serviceInstituicaoEnsino)
        {
            _serviceUsuario = serviceUsuario;
            _mapperUsuario = mapperUsuario;
            _serviceEndereco = serviceEndereco;
            _serviceInstituicaoEnsino = serviceInstituicaoEnsino;
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
            usuario.Endereco = _serviceEndereco.GetById(usuario.EnderecoID);
            usuario.InstituicaoEnsino = _serviceInstituicaoEnsino.GetById(usuario.InstituicaoEnsinoID);
            return _mapperUsuario.MapperEntityToDto(usuario);
        }

        public void Update(UsuarioDto usuarioDto)
        {
            var usuario = _mapperUsuario.MapperDtoToEntity(usuarioDto);
            _serviceUsuario.Update(usuario);
        }
    }
}
