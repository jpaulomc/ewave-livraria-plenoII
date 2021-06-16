using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Mappers;
using Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

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

            //Regra: Todo usuário pode emprestar no maximo 2 livros.
            var listEmprestimoLivro = _serviceEmprestimoLivro.GetAll();
            var emprestimosUsuario = listEmprestimoLivro.Where(e => e.UsuarioID == emprestimoLivroDto.UsuarioDto.Id);

            if (emprestimosUsuario.Count() >= 2)
                throw new System.Exception("Limite de emprestimo excedito, cada usuário pode emprestar até 2 livros.");

            //Regra: Todo emprestimo deve ser no maximo de 30 dias para cada livro.
            emprestimoLivro.DataEmprestimo = DateTime.Now;
            emprestimoLivro.DataPrazoEntrega = emprestimoLivro.DataEmprestimo.AddDays(30);

            //

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
