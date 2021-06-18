using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Mappers;
using Domain.Core.Interfaces.Services;
using System.Collections.Generic;

namespace Application
{
    public class ApplicationServiceReservaLivro : IApplicationServiceReservaLivro
    {
        private readonly IServiceReservaLivro _serviceReservaLivro;
        private readonly IMapperReservaLivro _mapperReservaLivro;

        public ApplicationServiceReservaLivro(IServiceReservaLivro serviceReservaLivro, IMapperReservaLivro mapperReservaLivro)
        {
            _serviceReservaLivro = serviceReservaLivro;
            _mapperReservaLivro = mapperReservaLivro;
        }

        public void Add(ReservaLivroDto reservaLivroDto)
        {
            var reservaLivro = _mapperReservaLivro.MapperDtoToEntity(reservaLivroDto);
            _serviceReservaLivro.Add(reservaLivro);
        }

        public IEnumerable<ReservaLivroDto> GetAll()
        {
            var reservaLivros = _serviceReservaLivro.GetAll();
            return _mapperReservaLivro.MapperListReservaLivrosDto(reservaLivros);
        }

        public ReservaLivroDto GetById(int id)
        {
            var reservaLivro = _serviceReservaLivro.GetById(id);
            return _mapperReservaLivro.MapperEntityToDto(reservaLivro);
        }

        public void Update(ReservaLivroDto reservaLivroDto)
        {
            var reservaLivro = _mapperReservaLivro.MapperDtoToEntity(reservaLivroDto);
            _serviceReservaLivro.Update(reservaLivro);
        }
    }
}
