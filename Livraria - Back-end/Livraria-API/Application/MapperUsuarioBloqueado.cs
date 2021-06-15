using Application.Dtos;
using Application.Interfaces.Mappers;
using Application.Mappers;
using Domain.Entitys;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class MapperUsuarioBloqueado : IMapperUsuarioBloqueado
    {
        private MapperUsuario _mapperUsuario;
        private MapperEmprestimoLivro _mapperEmprestimoLivro;
       
        public UsuarioBloqueado MapperDtoToEntity(UsuarioBloqueadoDto usuarioBloqueadoDto)
        {
            _mapperUsuario = new MapperUsuario();
            _mapperEmprestimoLivro = new MapperEmprestimoLivro();

            var usuarioBloqueado = new UsuarioBloqueado()
            {
                Id = usuarioBloqueadoDto.Id,
                DataBloqueio = usuarioBloqueadoDto.DataBloqueio,
                DataLiberacao = usuarioBloqueadoDto.DataLiberacao,
                StatusBloqueio = usuarioBloqueadoDto.StatusBloqueio,
                Usuario = _mapperUsuario.MapperDtoToEntity(usuarioBloqueadoDto.UsuarioDto),
                EmprestimoLivro = _mapperEmprestimoLivro.MapperDtoToEntity(usuarioBloqueadoDto.EmprestimoLivroDto)
            };

            return usuarioBloqueado;
        }

        public UsuarioBloqueadoDto MapperEntityToDto(UsuarioBloqueado usuarioBloqueado)
        {
            _mapperUsuario = new MapperUsuario();
            _mapperEmprestimoLivro = new MapperEmprestimoLivro();

            var usuarioBloqueadoDto = new UsuarioBloqueadoDto()
            {
                Id = usuarioBloqueado.Id,
                DataBloqueio = usuarioBloqueado.DataBloqueio,
                DataLiberacao = usuarioBloqueado.DataLiberacao,
                StatusBloqueio = usuarioBloqueado.StatusBloqueio,
                UsuarioDto = _mapperUsuario.MapperEntityToDto(usuarioBloqueado.Usuario),
                EmprestimoLivroDto = _mapperEmprestimoLivro.MapperEntityToDto(usuarioBloqueado.EmprestimoLivro)
            };

            return usuarioBloqueadoDto;
        }

        public IEnumerable<UsuarioBloqueadoDto> MapperListUsuarioBloqueadosDto(IEnumerable<UsuarioBloqueado> usuarioBloqueados)
        {
            _mapperUsuario = new MapperUsuario();
            _mapperEmprestimoLivro = new MapperEmprestimoLivro();

            var usuariosBloqueadoDto = usuarioBloqueados.Select(u => new UsuarioBloqueadoDto()
            {
                Id = u.Id,
                DataBloqueio = u.DataBloqueio,
                DataLiberacao = u.DataLiberacao,
                StatusBloqueio = u.StatusBloqueio,
                UsuarioDto = _mapperUsuario.MapperEntityToDto(u.Usuario),
                EmprestimoLivroDto = _mapperEmprestimoLivro.MapperEntityToDto(u.EmprestimoLivro)
            });

            return usuariosBloqueadoDto;
        }
    }
}
