using Application.Dtos;
using Domain.Entitys;
using System.Collections.Generic;

namespace Application.Interfaces.Mappers
{
    public interface IMapperReservaLivro
    {
        ReservaLivro MapperDtoToEntity(ReservaLivroDto reservaLivroDto);
        IEnumerable<ReservaLivroDto> MapperListReservaLivrosDto(IEnumerable<ReservaLivro> reservaLivros);
        ReservaLivroDto MapperEntityToDto(ReservaLivro reservaLivro);
    }
}
