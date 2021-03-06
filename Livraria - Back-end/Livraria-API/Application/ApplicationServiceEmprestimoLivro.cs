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
        private readonly IServiceUsuarioBloqueado _serviceUsuarioBloqueado;
        private readonly IServiceLivro _serviceLivro;
        private readonly IServiceReservaLivro _serviceReservaLivro;

        public ApplicationServiceEmprestimoLivro(IServiceEmprestimoLivro serviceEmprestimoLivro, IMapperEmprestimoLivro mapperEmprestimoLivro, 
            IServiceUsuarioBloqueado serviceUsuarioBloqueado, IServiceLivro serviceLivro, IServiceReservaLivro serviceReservaLivro)
        {
            _serviceEmprestimoLivro = serviceEmprestimoLivro;
            _mapperEmprestimoLivro = mapperEmprestimoLivro;
            _serviceUsuarioBloqueado = serviceUsuarioBloqueado;
            _serviceLivro = serviceLivro;
            _serviceReservaLivro = serviceReservaLivro;
        }

        public void Add(EmprestimoLivroDto emprestimoLivroDto)
        {
            var emprestimoLivro = _mapperEmprestimoLivro.MapperDtoToEntity(emprestimoLivroDto);


            //Regra: Livros emprestados deverão estar indisponiveis para outros Usuários.
            if (emprestimoLivro.Livro.StatusLivro == Domain.Entitys.StatusLivroEnum.Emprestado)
                throw new Exception("Livro impossibilitado de emprestimo, pois já esta emprestado a outro usuário.");

            //Regra: Permitir reservar livros
            var reservasLivro = _serviceReservaLivro.GetAll();
            var registroReservaLivro = reservasLivro.Where(r => r.Livro.Id == emprestimoLivro.Livro.Id && r.Usuario.Id != emprestimoLivro.Usuario.Id && r.Ativa);

            if (registroReservaLivro.Count() > 0)
                throw new Exception("Livro impossibilitado de emprestimo, pois já esta reservado para outro usuário.");


            //Regra: O Usuário que infringir a regra dos dias fica impossibilitado de emprestar qualquer outro livro até a devolução e só poderá emprestar novamente após 30 dias.
            var listUsuariosBloqueado = _serviceUsuarioBloqueado.GetAll();
            var registroUsuarioBloqueado = listUsuariosBloqueado.Where(ub => ub.UsuarioID == emprestimoLivroDto.UsuarioDto.Id && ub.StatusBloqueio);

            if (registroUsuarioBloqueado.Count() > 0)
                throw new Exception("Usuário impossibilitado de emprestar livros devido atraso em devolução anterior.");


            //Regra: Todo usuário pode emprestar no maximo 2 livros.
            var listEmprestimoLivro = _serviceEmprestimoLivro.GetAll();
            var emprestimosUsuario = listEmprestimoLivro.Where(e => e.UsuarioID == emprestimoLivroDto.UsuarioDto.Id);

            if (emprestimosUsuario.Count() >= 2)
                throw new Exception("Limite de emprestimo excedito, cada usuário pode emprestar até 2 livros.");

            //Regra: Todo emprestimo deve ser no maximo de 30 dias para cada livro.
            emprestimoLivro.DataEmprestimo = DateTime.Now;
            emprestimoLivro.DataPrazoEntrega = emprestimoLivro.DataEmprestimo.AddDays(30);

            _serviceEmprestimoLivro.Add(emprestimoLivro);

            //Alterando o status do Livro para Emprestado
            emprestimoLivro.Livro.StatusLivro = Domain.Entitys.StatusLivroEnum.Emprestado;
            _serviceLivro.Update(emprestimoLivro.Livro);

            //Se havia uma reserva desse livro para esse mesmo usuário, desativar reserva.
            var registroReservaLivroAtiva = reservasLivro.Where(r => r.Livro.Id == emprestimoLivro.Livro.Id && r.Usuario.Id == emprestimoLivro.Usuario.Id && r.Ativa);
            if (registroReservaLivroAtiva.Count() > 0)
                _serviceReservaLivro.Update(registroReservaLivroAtiva.First());

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
