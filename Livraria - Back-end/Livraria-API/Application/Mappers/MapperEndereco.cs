using Application.Dtos;
using Application.Interfaces.Mappers;
using Domain.Entitys;
using System.Collections.Generic;
using System.Linq;

namespace Application.Mappers
{
    public class MapperEndereco : IMapperEndereco
    {
        public Endereco MapperDtoToEntity(EnderecoDto enderecoDto)
        {
            var endereco = new Endereco()
            {
                Id = enderecoDto.Id,
                Logradouro = enderecoDto.Logradouro,
                Bairro = enderecoDto.Bairro,
                Cidade = enderecoDto.Cidade,
                UF = enderecoDto.UF,
                Pais = enderecoDto.Pais,
                CEP = enderecoDto.CEP
            };

            return endereco;
        }

        public EnderecoDto MapperEntityToDto(Endereco endereco)
        {
            var enderecoDto = new EnderecoDto()
            {
                Id = endereco.Id,
                Logradouro = endereco.Logradouro,
                Bairro = endereco.Bairro,
                Cidade = endereco.Cidade,
                UF = endereco.UF,
                Pais = endereco.Pais,
                CEP = endereco.CEP
            };

            return enderecoDto;
        }

        public IEnumerable<EnderecoDto> MapperListEnderecosDto(IEnumerable<Endereco> endereco)
        {
            var enderecos = endereco.Select(e => new EnderecoDto()
            {
                Id = e.Id,
                Logradouro = e.Logradouro,
                Bairro = e.Bairro,
                Cidade = e.Cidade,
                UF = e.UF,
                Pais = e.Pais,
                CEP = e.CEP
            });

            return enderecos;
        }
    }
}
