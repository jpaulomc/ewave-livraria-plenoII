using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Mappers;
using Domain.Core.Interfaces.Services;
using System.Collections.Generic;

namespace Application
{
    public class ApplicationServiceEmprestimoLivro : IApplicationServiceEmprestimoLivro
    {
        private readonly IServiceEmprestimoLivro _serviceEmprestimoLivro;
        private readonly IMapperEmprestimoLivro _mapperEmprestimoLivro;

        public ApplicationServiceEmprestimoLivro(IServiceEmprestimoLivro serviceEmprestimoLivro, IMapperEmprestimoLivro mapperEmprestimoLivro)
        {
            _serviceEmprestimoLivro = serviceEmprestimoLivro;
            _mapperEmprestimoLivro = mapperEmprestimoLivro;
        }

        public void Add(EmprestimoLivroDto emprestimoLivroDto)
        {
            var emprestimoLivro = _mapperEmprestimoLivro.MapperDtoToEntity(emprestimoLivroDto);
            _serviceEmprestimoLivro.Add(emprestimoLivro);
        }

        public IEnumerable<EmprestimoLivroDto> GetAll()
        {
            var emprestimoLivro = _serviceEmprestimoLivro.GetAll();
            return _mapperEmprestimoLivro.MapperListEmprestimoLivrosDto(emprestimoLivro);
        }

        public EmprestimoLivroDto GetById(int id)
        {
            var emprestimoLivro = _serviceEmprestimoLivro.GetById(id);
            return _mapperEmprestimoLivro.MapperEntityToDto(emprestimoLivro);
        }

        public void Update(EmprestimoLivroDto emprestimoLivroDto)
        {
            var emprestimoLivro = _mapperEmprestimoLivro.MapperDtoToEntity(emprestimoLivroDto);
            _serviceEmprestimoLivro.Update(emprestimoLivro);
        }
    }
}
