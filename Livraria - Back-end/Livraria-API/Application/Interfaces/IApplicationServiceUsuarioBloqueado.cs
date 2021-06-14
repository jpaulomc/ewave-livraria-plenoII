using Application.Dtos;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IApplicationServiceUsuarioBloqueado
    {
        void Add(UsuarioBloqueadoDto usuarioBloqueadoDto);
        void Update(UsuarioBloqueadoDto usuarioBloqueadoDto);
        IEnumerable<UsuarioBloqueadoDto> GetAll();
        UsuarioBloqueadoDto GetById(int id);
    }
}
