using Application.Dtos;
using Application.Interfaces.Mappers;
using Domain.Entitys;
using System.Collections.Generic;
using System.Linq;

namespace Application.Mappers
{
    public class MapperInstituicaoEnsino : IMapperInstituicaoEnsino
    {
        private MapperEndereco _mapperEndereco;

        public InstituicaoEnsino MapperDtoToEntity(InstituicaoEnsinoDto instituicaoEnsinoDto)
        {
            _mapperEndereco = new MapperEndereco();

            var instituicaoEnsino = new InstituicaoEnsino()
            {
                Id = instituicaoEnsinoDto.Id,
                EnderecoID = instituicaoEnsinoDto.EnderecoDto.Id,
                Nome = instituicaoEnsinoDto.Nome,
                Endereco = _mapperEndereco.MapperDtoToEntity(instituicaoEnsinoDto.EnderecoDto),
                CNPJ = instituicaoEnsinoDto.CNPJ,
                Telefone = instituicaoEnsinoDto.Telefone,
                Ativo = instituicaoEnsinoDto.Ativo
            };

            return instituicaoEnsino;
        }

        public InstituicaoEnsinoDto MapperEntityToDto(InstituicaoEnsino instituicaoEnsino)
        {
            _mapperEndereco = new MapperEndereco();

            var instituicaoEnsinoDto = new InstituicaoEnsinoDto()
            {
                Id = instituicaoEnsino.Id,
                EnderecoID = instituicaoEnsino.Endereco.Id,
                Nome = instituicaoEnsino.Nome,
                EnderecoDto = _mapperEndereco.MapperEntityToDto(instituicaoEnsino.Endereco),
                CNPJ = instituicaoEnsino.CNPJ,
                Telefone = instituicaoEnsino.Telefone,
                Ativo = instituicaoEnsino.Ativo
            };

            return instituicaoEnsinoDto;
        }

        public IEnumerable<InstituicaoEnsinoDto> MapperListInstituicaoEnsinosDto(IEnumerable<InstituicaoEnsino> instituicaoEnsino)
        {
            _mapperEndereco = new MapperEndereco();

            var dto = instituicaoEnsino.Select(ies => new InstituicaoEnsinoDto
            {
                Id = ies.Id,
                EnderecoID = ies.EnderecoID,
                Nome = ies.Nome,
                EnderecoDto = _mapperEndereco.MapperEntityToDto(ies.Endereco),
                CNPJ = ies.CNPJ,
                Telefone = ies.Telefone,
                Ativo = ies.Ativo
            });

            return dto;
        }
    }
}
