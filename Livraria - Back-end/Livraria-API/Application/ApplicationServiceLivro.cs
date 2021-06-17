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
        private readonly IServiceGenero _serviceGenero;
        private readonly IServiceAutor _serviceAutor;

        public ApplicationServiceLivro(IServiceLivro serviceLivro, IMapperLivro mapperLivro,
            IServiceGenero serviceGenero, IServiceAutor serviceAutor)
        {
            _serviceLivro = serviceLivro;
            _mapperLivro = mapperLivro;
            _serviceGenero = serviceGenero;
            _serviceAutor = serviceAutor;
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
            livro.Genero = _serviceGenero.GetById(livro.GeneroID);
            livro.Autor = _serviceAutor.GetById(livro.AutorID);
            return _mapperLivro.MapperEntityToDto(livro);
        }

        public void Update(LivroDto livroDto)
        {
            var livro = _mapperLivro.MapperDtoToEntity(livroDto);
            _serviceLivro.Update(livro);
        }
    }
}
