using Application.Dtos;
using Application.Interfaces.Mappers;
using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Mappers
{
    public class MapperInstituicaoEnsino : IMapperInstituicaoEnsino
    {
        private MapperEndereco _mapperEndereco;

        public InstituicaoEnsino MapperDtoToEntity(InstituicaoEnsinoDto instituicaoEnsinoDto)
        {
            var instituicaoEnsino = new InstituicaoEnsino()
            {
                Id = instituicaoEnsinoDto.Id,
                Nome = instituicaoEnsinoDto.Nome,
                Endereco = _mapperEndereco.MapperDtoToEntity(instituicaoEnsinoDto.Endereco),
                CNPJ = instituicaoEnsinoDto.CNPJ,
                Telefone = instituicaoEnsinoDto.Telefone,
                Ativo = instituicaoEnsinoDto.Ativo
            };

            return instituicaoEnsino;
        }

        public InstituicaoEnsinoDto MapperEntityToDto(InstituicaoEnsino instituicaoEnsino)
        {
            var instituicaoEnsinoDto = new InstituicaoEnsinoDto()
            {
                Id = instituicaoEnsino.Id,
                Nome = instituicaoEnsino.Nome,
                Endereco = _mapperEndereco.MapperEntityToDto(instituicaoEnsino.Endereco),
                CNPJ = instituicaoEnsino.CNPJ,
                Telefone = instituicaoEnsino.Telefone,
                Ativo = instituicaoEnsino.Ativo
            };

            return instituicaoEnsinoDto;
        }

        public IEnumerable<InstituicaoEnsinoDto> MapperListInstituicaoEnsinosDto(IEnumerable<InstituicaoEnsino> instituicaoEnsino)
        {
            var dto = instituicaoEnsino.Select(ies => new InstituicaoEnsinoDto
            {
                Id = ies.Id,
                Nome = ies.Nome,
                Endereco = _mapperEndereco.MapperEntityToDto(ies.Endereco),
                CNPJ = ies.CNPJ,
                Telefone = ies.Telefone,
                Ativo = ies.Ativo
            });

            return dto;
        }
    }
}
