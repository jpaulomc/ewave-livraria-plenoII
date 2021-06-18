using Application.Dtos;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IApplicationServiceInstituicaoEnsino
    {
        void Add(InstituicaoEnsinoDto instituicaoEnsinoDto);
        void Update(InstituicaoEnsinoDto instituicaoEnsinoDto);
        IEnumerable<InstituicaoEnsinoDto> GetAll();
        InstituicaoEnsinoDto GetById(int id);
    }
}
