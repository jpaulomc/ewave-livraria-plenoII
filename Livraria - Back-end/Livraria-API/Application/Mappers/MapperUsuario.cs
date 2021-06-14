using Application.Dtos;
using Application.Interfaces.Mappers;
using Domain.Entitys;
using System.Collections.Generic;
using System.Linq;

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
                Endereco = _mapperEndereco.MapperDtoToEntity(usuarioDto.EnderecoDto),
                CPF = usuarioDto.CPF,
                InstituicaoEnsino = _mapperInstituicaoEnsino.MapperDtoToEntity(usuarioDto.InstituicaoEnsinoDto),
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
                EnderecoDto = _mapperEndereco.MapperEntityToDto(usuario.Endereco),
                CPF = usuario.CPF,
                InstituicaoEnsinoDto = _mapperInstituicaoEnsino.MapperEntityToDto(usuario.InstituicaoEnsino),
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
                EnderecoDto = _mapperEndereco.MapperEntityToDto(u.Endereco),
                CPF = u.CPF,
                InstituicaoEnsinoDto = _mapperInstituicaoEnsino.MapperEntityToDto(u.InstituicaoEnsino),
                Telefone = u.Telefone,
                Email = u.Email,
                Ativo = u.Ativo
            });

            return dto;
        }
    }
}
