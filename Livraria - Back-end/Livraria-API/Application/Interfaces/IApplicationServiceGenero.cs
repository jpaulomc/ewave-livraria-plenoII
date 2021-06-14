using Application.Dtos;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IApplicationServiceGenero
    {
        void Add(GeneroDto generoDto);
        void Update(GeneroDto generoDto);
        IEnumerable<GeneroDto> GetAll();
        GeneroDto GetById(int id);
    }
}
