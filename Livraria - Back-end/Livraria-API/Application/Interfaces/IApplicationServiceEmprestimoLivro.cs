using Application.Dtos;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IApplicationServiceEmprestimoLivro
    {
        void Add(EmprestimoLivroDto emprestimoLivroDto);
        void Update(EmprestimoLivroDto emprestimoLivroDto);
        IEnumerable<EmprestimoLivroDto> GetAll();
        EmprestimoLivroDto GetById(int id);
    }
}
