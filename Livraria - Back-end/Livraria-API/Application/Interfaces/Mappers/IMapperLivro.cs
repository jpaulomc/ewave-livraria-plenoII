using Application.Dtos;
using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Mappers
{
    public interface IMapperLivro
    {
        Livro MapperDtoToEntity(LivroDto livroDto);
        IEnumerable<LivroDto> MapperListLivrosDto(IEnumerable<Livro> livro);
        LivroDto MapperEntityToDto(Livro livro);
    }
}
