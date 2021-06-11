using Application.Dtos;
using Domain.Entitys;
using System.Collections.Generic;

namespace Application.Interfaces.Mappers
{
    public interface IMapperInstituicaoEnsino
    {
        InstituicaoEnsino MapperDtoToEntity(InstituicaoEnsinoDto instituicaoEnsinoDto);
        IEnumerable<InstituicaoEnsinoDto> MapperListInstituicaoEnsinosDto(IEnumerable<InstituicaoEnsino> instituicaoEnsino);
        InstituicaoEnsinoDto MapperEntityToDto(InstituicaoEnsino instituicaoEnsino);
    }
}
