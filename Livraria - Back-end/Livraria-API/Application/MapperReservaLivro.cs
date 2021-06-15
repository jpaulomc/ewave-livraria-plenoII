using Application.Dtos;
using Application.Interfaces.Mappers;
using Application.Mappers;
using Domain.Entitys;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class MapperReservaLivro : IMapperReservaLivro
    {
        private MapperLivro _mapperLivro;
        private MapperUsuario _mapperUsuario;

        public ReservaLivro MapperDtoToEntity(ReservaLivroDto reservaLivroDto)
        {
            _mapperLivro = new MapperLivro();
            _mapperUsuario = new MapperUsuario();

            var reservaLivro = new ReservaLivro()
            {
                Id = reservaLivroDto.Id,
                Ativa = reservaLivroDto.Ativa,
                Livro = _mapperLivro.MapperDtoToEntity(reservaLivroDto.LivroDto),
                Usuario = _mapperUsuario.MapperDtoToEntity(reservaLivroDto.UsuarioDto)
            };

            return reservaLivro;
        }

        public ReservaLivroDto MapperEntityToDto(ReservaLivro reservaLivro)
        {
            _mapperLivro = new MapperLivro();
            _mapperUsuario = new MapperUsuario();

            var reservaLivroDto = new ReservaLivroDto()
            {
                Id = reservaLivro.Id,
                Ativa = reservaLivro.Ativa,
                LivroDto = _mapperLivro.MapperEntityToDto(reservaLivro.Livro),
                UsuarioDto = _mapperUsuario.MapperEntityToDto(reservaLivro.Usuario)
            };

            return reservaLivroDto;
        }

        public IEnumerable<ReservaLivroDto> MapperListReservaLivrosDto(IEnumerable<ReservaLivro> reservaLivros)
        {
            _mapperLivro = new MapperLivro();
            _mapperUsuario = new MapperUsuario();

            var reservasLivro = reservaLivros.Select(rv => new ReservaLivroDto()
            {
                Id = rv.Id,
                Ativa = rv.Ativa,
                LivroDto = _mapperLivro.MapperEntityToDto(rv.Livro),
                UsuarioDto = _mapperUsuario.MapperEntityToDto(rv.Usuario)
            });

            return reservasLivro;
        }
    }
}
