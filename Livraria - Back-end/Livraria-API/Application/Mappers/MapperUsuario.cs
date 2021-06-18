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
                EnderecoID = usuarioDto.EnderecoID,
                CPF = usuarioDto.CPF,
                InstituicaoEnsinoID = usuarioDto.InstituicaoEnsinoID,
                Telefone = usuarioDto.Telefone,
                Email = usuarioDto.Email,
                Ativo = usuarioDto.Ativo,
                Endereco = _mapperEndereco.MapperDtoToEntity(usuarioDto.EnderecoDto)
            };

            return usuario;
        }

        public UsuarioDto MapperEntityToDto(Usuario usuario)
        {
            _mapperEndereco = new MapperEndereco();
            _mapperInstituicaoEnsino = new MapperInstituicaoEnsino();

            var enderecoDto = _mapperEndereco.MapperEntityToDto(usuario.Endereco);
            var instituicaoEnsinoDto = _mapperInstituicaoEnsino.MapperEntityToDto(usuario.InstituicaoEnsino);

            var usuarioDto = new UsuarioDto()
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                EnderecoID = enderecoDto.Id,
                CPF = usuario.CPF,
                InstituicaoEnsinoID = instituicaoEnsinoDto.Id,
                InstituicaoEnsino = instituicaoEnsinoDto.Nome,
                Telefone = usuario.Telefone,
                Email = usuario.Email,
                Ativo = usuario.Ativo,
                EnderecoDto = enderecoDto
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
                EnderecoID = _mapperEndereco.MapperEntityToDto(u.Endereco).Id,
                CPF = u.CPF,
                InstituicaoEnsinoID = _mapperInstituicaoEnsino.MapperEntityToDto(u.InstituicaoEnsino).Id,
                InstituicaoEnsino = _mapperInstituicaoEnsino.MapperEntityToDto(u.InstituicaoEnsino).Nome,
                Telefone = u.Telefone,
                Email = u.Email,
                Ativo = u.Ativo,
                EnderecoDto = _mapperEndereco.MapperEntityToDto(u.Endereco)
            });

            return dto;
        }
    }
}
