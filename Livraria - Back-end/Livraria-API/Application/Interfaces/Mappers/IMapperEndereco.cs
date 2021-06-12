using Application.Dtos;
using Domain.Entitys;

namespace Application.Interfaces.Mappers
{
    public interface IMapperEndereco
    {
        Endereco MapperDtoToEntity(EnderecoDto enderecoDto);
        EnderecoDto MapperEntityToDto(Endereco endereco);
    }
}
