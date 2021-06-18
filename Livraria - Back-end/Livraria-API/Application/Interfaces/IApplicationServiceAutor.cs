using Application.Dtos;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IApplicationServiceAutor
    {
        void Add(AutorDto autorDto);
        void Update(AutorDto autorDto);
        IEnumerable<AutorDto> GetAll();
        AutorDto GetById(int id);
    }
}
