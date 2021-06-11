using Application.Dtos;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IApplicationServiceLivro
    {
        void Add(LivroDto livroDto);
        void Update(LivroDto livroDto);
        IEnumerable<LivroDto> GetAll();
        LivroDto GetById(int id);
    }
}
