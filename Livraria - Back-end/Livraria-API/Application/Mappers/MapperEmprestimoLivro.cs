using Application.Dtos;
using Application.Interfaces.Mappers;
using Domain.Entitys;
using System.Collections.Generic;
using System.Linq;

namespace Application.Mappers
{
    public class MapperEmprestimoLivro : IMapperEmprestimoLivro
    {
        private MapperLivro _mapperLivro;
        private MapperUsuario _mapperUsuario;

        public EmprestimoLivro MapperDtoToEntity(EmprestimoLivroDto emprestimoLivroDto)
        {
            _mapperLivro = new MapperLivro();
            _mapperUsuario = new MapperUsuario();

            var emprestimoLivro = new EmprestimoLivro()
            {
                Id = emprestimoLivroDto.Id,
                DataEmprestimo = emprestimoLivroDto.DataEmprestimo,
                DataPrazoEntrega = emprestimoLivroDto.DataPrazoEntrega,
                DataEntrega = emprestimoLivroDto.DataEntrega,
                Livro = _mapperLivro.MapperDtoToEntity(emprestimoLivroDto.LivroDto),
                Usuario = _mapperUsuario.MapperDtoToEntity(emprestimoLivroDto.UsuarioDto)
            };

            return emprestimoLivro;
        }

        public EmprestimoLivroDto MapperEntityToDto(EmprestimoLivro emprestimoLivro)
        {
            var emprestimoLivroDto = new EmprestimoLivroDto()
            {
                Id = emprestimoLivro.Id,
                DataEmprestimo = emprestimoLivro.DataEmprestimo,
                DataPrazoEntrega = emprestimoLivro.DataPrazoEntrega,
                DataEntrega = emprestimoLivro.DataEntrega,
                LivroDto = _mapperLivro.MapperEntityToDto(emprestimoLivro.Livro),
                UsuarioDto = _mapperUsuario.MapperEntityToDto(emprestimoLivro.Usuario)
            };

            return emprestimoLivroDto;
        }

        public IEnumerable<EmprestimoLivroDto> MapperListEmprestimoLivrosDto(IEnumerable<EmprestimoLivro> emprestimoLivros)
        {
            var emprestimosLivro = emprestimoLivros.Select(emp => new EmprestimoLivroDto()
            {
                Id = emp.Id,
                DataEmprestimo = emp.DataEmprestimo,
                DataPrazoEntrega = emp.DataPrazoEntrega,
                DataEntrega = emp.DataEntrega,
                LivroDto = _mapperLivro.MapperEntityToDto(emp.Livro),
                UsuarioDto = _mapperUsuario.MapperEntityToDto(emp.Usuario)
            });

            return emprestimosLivro;
        }
    }
}
