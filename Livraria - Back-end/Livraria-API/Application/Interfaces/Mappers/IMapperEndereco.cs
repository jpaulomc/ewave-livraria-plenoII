using Application.Dtos;
using Domain.Entitys;
using System.Collections.Generic;

namespace Application.Interfaces.Mappers
{
    public interface IMapperEndereco
    {
        Endereco MapperDtoToEntity(EnderecoDto enderecoDto);
        IEnumerable<EnderecoDto> MapperListEnderecosDto(IEnumerable<Endereco> endereco);
        EnderecoDto MapperEntityToDto(Endereco endereco);
    }
}
