using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Mappers;
using Domain.Core.Interfaces.Services;
using System.Collections.Generic;

namespace Application
{
    public class ApplicationServiceLivro : IApplicationServiceLivro
    {
        private readonly IServiceLivro _serviceLivro;
        private readonly IMapperLivro _mapperLivro;

        public ApplicationServiceLivro(IServiceLivro serviceLivro, IMapperLivro mapperLivro)
        {
            _serviceLivro = serviceLivro;
            _mapperLivro = mapperLivro;
        }

        public void Add(LivroDto livroDto)
        {
            var livro = _mapperLivro.MapperDtoToEntity(livroDto);
            _serviceLivro.Add(livro);
        }

        public IEnumerable<LivroDto> GetAll()
        {
            var livros = _serviceLivro.GetAll();
            return _mapperLivro.MapperListLivrosDto(livros);
        }

        public LivroDto GetById(int id)
        {
            var livro = _serviceLivro.GetById(id);
            return _mapperLivro.MapperEntityToDto(livro);
        }

        public void Update(LivroDto livroDto)
        {
            var livro = _mapperLivro.MapperDtoToEntity(livroDto);
            _serviceLivro.Update(livro);
        }
    }
}
