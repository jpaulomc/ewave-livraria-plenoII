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
                GeneroID = livroDto.GeneroID,
                AutorID = livroDto.AutorID,
                Titulo = livroDto.Titulo,
                Sinopse = livroDto.Sinopse,
                Capa = livroDto.Capa,
                Ativo = livroDto.Ativo,
                StatusLivro = livroDto.StatusLivro
            };

            return livro;
        }

        public LivroDto MapperEntityToDto(Livro livro)
        {
            _mapperAutor = new MapperAutor();
            _mapperGenero = new MapperGenero();

            var generoDto = _mapperGenero.MapperEntityToDto(livro.Genero);
            var autorDto = _mapperAutor.MapperEntityToDto(livro.Autor);

            var livroDto = new LivroDto()
            {
                Id = livro.Id,
                GeneroID = generoDto.Id,
                GeneroDescricao = generoDto.Descricao,
                AutorID = autorDto.Id,
                AutorNome = autorDto.Nome,
                Titulo = livro.Titulo,
                Sinopse = livro.Sinopse,
                Capa = livro.Capa,
                Ativo = livro.Ativo,
                StatusLivro = livro.StatusLivro
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
                GeneroID = _mapperGenero.MapperEntityToDto(l.Genero).Id,
                GeneroDescricao = _mapperGenero.MapperEntityToDto(l.Genero).Descricao,
                AutorID = _mapperAutor.MapperEntityToDto(l.Autor).Id,
                AutorNome = _mapperAutor.MapperEntityToDto(l.Autor).Nome,
                Titulo = l.Titulo,
                Sinopse = l.Sinopse,
                Capa = l.Capa,
                Ativo = l.Ativo,
                StatusLivro = l.StatusLivro
            });

            return dto;
        }
    }
}
