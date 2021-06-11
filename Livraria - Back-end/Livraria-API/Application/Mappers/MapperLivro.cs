using Application.Dtos;
using Application.Interfaces.Mappers;
using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Mappers
{
    public class MapperLivro : IMapperLivro
    {
        public Livro MapperDtoToEntity(LivroDto livroDto)
        {
            var livro = new Livro()
            {
                Id = livroDto.Id,
                Titulo = livroDto.Titulo,
                Genero = livroDto.Genero,
                Autor = livroDto.Autor,
                Sinopse = livroDto.Sinopse,
                Capa = livroDto.Capa,
                Ativo = livroDto.Ativo
            };

            return livro;
        }

        public LivroDto MapperEntityToDto(Livro livro)
        {
            var livroDto = new LivroDto()
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                Genero = livro.Genero,
                Autor = livro.Autor,
                Sinopse = livro.Sinopse,
                Capa = livro.Capa,
                Ativo = livro.Ativo
            };

            return livroDto;
        }

        public IEnumerable<LivroDto> MapperListLivrosDto(IEnumerable<Livro> livro)
        {
            var dto = livro.Select(l => new LivroDto
            {
                Id = l.Id,
                Titulo = l.Titulo,
                Genero = l.Genero,
                Autor = l.Autor,
                Sinopse = l.Sinopse,
                Capa = l.Capa,
                Ativo = l.Ativo
            });

            return dto;
        }
    }
}
