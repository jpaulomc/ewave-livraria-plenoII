using Application.Dtos;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IApplicationServiceEnderecoDto
    {
        void Add(EnderecoDto enderecoDto);
        void Update(EnderecoDto enderecoDto);
        IEnumerable<EnderecoDto> GetAll();
        EnderecoDto GetById(int id);
    }
}
