using Application.Dtos;
using Domain.Entitys;
using System.Collections.Generic;

namespace Application.Interfaces.Mappers
{
    public interface IMapperLivro
    {
        Livro MapperDtoToEntity(LivroDto livroDto);
        IEnumerable<LivroDto> MapperListLivrosDto(IEnumerable<Livro> livro);
        LivroDto MapperEntityToDto(Livro livro);
    }
}
