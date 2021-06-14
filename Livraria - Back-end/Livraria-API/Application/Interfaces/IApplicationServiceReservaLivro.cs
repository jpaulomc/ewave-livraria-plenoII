using Application.Dtos;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IApplicationServiceReservaLivro
    {
        void Add(ReservaLivroDto reservaLivroDto);
        void Update(ReservaLivroDto reservaLivroDto);
        IEnumerable<ReservaLivroDto> GetAll();
        ReservaLivroDto GetById(int id);
    }
}
