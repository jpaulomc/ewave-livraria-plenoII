using Application.Dtos;
using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Mappers
{
    public interface IMapperEndereco
    {
        Endereco MapperDtoToEntity(EnderecoDto enderecoDto);
        EnderecoDto MapperEntityToDto(Endereco endereco);
    }
}
