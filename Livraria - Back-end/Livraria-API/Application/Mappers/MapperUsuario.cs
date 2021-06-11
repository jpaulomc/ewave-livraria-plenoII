using Application.Dtos;
using Application.Interfaces.Mappers;
using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Mappers
{
    public class MapperUsuario : IMapperUsuario
    {
        private MapperEndereco _mapperEndereco;
        private MapperInstituicaoEnsino _mapperInstituicaoEnsino;

        public Usuario MapperDtoToEntity(UsuarioDto usuarioDto)
        {
            _mapperEndereco = new MapperEndereco();
            _mapperInstituicaoEnsino = new MapperInstituicaoEnsino();

            var usuario = new Usuario()
            {
                Id = usuarioDto.Id,
                Nome = usuarioDto.Nome,
                Endereco = _mapperEndereco.MapperDtoToEntity(usuarioDto.Endereco),
                CPF = usuarioDto.CPF,
                InstituicaoEnsino = _mapperInstituicaoEnsino.MapperDtoToEntity(usuarioDto.InstituicaoEnsino),
                Telefone = usuarioDto.Telefone,
                Email = usuarioDto.Email,
                Ativo = usuarioDto.Ativo
            };

            return usuario;
        }

        public UsuarioDto MapperEntityToDto(Usuario usuario)
        {
            _mapperEndereco = new MapperEndereco();
            _mapperInstituicaoEnsino = new MapperInstituicaoEnsino();

            var usuarioDto = new UsuarioDto()
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Endereco = _mapperEndereco.MapperEntityToDto(usuario.Endereco),
                CPF = usuario.CPF,
                InstituicaoEnsino = _mapperInstituicaoEnsino.MapperEntityToDto(usuario.InstituicaoEnsino),
                Telefone = usuario.Telefone,
                Email = usuario.Email,
                Ativo = usuario.Ativo
            };

            return usuarioDto;
        }

        public IEnumerable<UsuarioDto> MapperListUsuariosDto(IEnumerable<Usuario> usuarios)
        {
            _mapperEndereco = new MapperEndereco();
            _mapperInstituicaoEnsino = new MapperInstituicaoEnsino();

            var dto = usuarios.Select( u => new UsuarioDto
            {
                Id = u.Id,
                Nome = u.Nome,
                Endereco = _mapperEndereco.MapperEntityToDto(u.Endereco),
                CPF = u.CPF,
                InstituicaoEnsino = _mapperInstituicaoEnsino.MapperEntityToDto(u.InstituicaoEnsino),
                Telefone = u.Telefone,
                Email = u.Email,
                Ativo = u.Ativo
            });

            return dto;
        }
    }
}
