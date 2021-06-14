using Application.Dtos;
using Domain.Entitys;
using System.Collections.Generic;

namespace Application.Interfaces.Mappers
{
    public interface IMapperEmprestimoLivro
    {
        EmprestimoLivro MapperDtoToEntity(EmprestimoLivroDto emprestimoLivroDto);
        IEnumerable<EmprestimoLivroDto> MapperListEmprestimoLivrosDto(IEnumerable<EmprestimoLivro> emprestimoLivros);
        EmprestimoLivroDto MapperEntityToDto(EmprestimoLivro emprestimoLivro);
    }
}
