using Application.Dtos;
using Application.Interfaces.Mappers;
using Domain.Entitys;
using System.Collections.Generic;
using System.Linq;

namespace Application.Mappers
{
    public class MapperLivro : IMapperLivro
    {
        private MapperAutor _mapperAutor;
        private MapperGenero _mapperGenero;

        public Livro MapperDtoToEntity(LivroDto livroDto)
        {
            _mapperAutor = new MapperAutor();
            _mapperGenero = new MapperGenero();

            var livro = new Livro()
            {
                Id = livroDto.Id,
                Titulo = livroDto.Titulo,
                Genero = _mapperGenero.MapperDtoToEntity(livroDto.GeneroDto),
                Autor = _mapperAutor.MapperDtoToEntity(livroDto.AutorDto),
                Sinopse = livroDto.Sinopse,
                Capa = livroDto.Capa,
                Ativo = livroDto.Ativo
            };

            return livro;
        }

        public LivroDto MapperEntityToDto(Livro livro)
        {
            _mapperAutor = new MapperAutor();
            _mapperGenero = new MapperGenero();

            var livroDto = new LivroDto()
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                GeneroDto = _mapperGenero.MapperEntityToDto(livro.Genero),
                AutorDto = _mapperAutor.MapperEntityToDto(livro.Autor),
                Sinopse = livro.Sinopse,
                Capa = livro.Capa,
                Ativo = livro.Ativo
            };

            return livroDto;
        }

        public IEnumerable<LivroDto> MapperListLivrosDto(IEnumerable<Livro> livro)
        {
            _mapperAutor = new MapperAutor();
            _mapperGenero = new MapperGenero();

            var dto = livro.Select(l => new LivroDto
            {
                Id = l.Id,
                Titulo = l.Titulo,
                GeneroDto = _mapperGenero.MapperEntityToDto(l.Genero),
                AutorDto = _mapperAutor.MapperEntityToDto(l.Autor),
                Sinopse = l.Sinopse,
                Capa = l.Capa,
                Ativo = l.Ativo
            });

            return dto;
        }
    }
}
