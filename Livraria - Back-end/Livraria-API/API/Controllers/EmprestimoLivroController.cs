using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    public class EmprestimoLivroController : Controller
    {
        private readonly IApplicationServiceEmprestimoLivro _applicationServiceEmprestimoLivro;

        public EmprestimoLivroController(IApplicationServiceEmprestimoLivro applicationServiceEmprestimoLivro)
        {
            _applicationServiceEmprestimoLivro = applicationServiceEmprestimoLivro;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceEmprestimoLivro.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationServiceEmprestimoLivro.GetById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] EmprestimoLivroDto emprestimoLivroDto)
        {
            try
            {
                if (emprestimoLivroDto == null)
                {
                    return NotFound();
                }

                _applicationServiceEmprestimoLivro.Add(emprestimoLivroDto);
                return Ok("Emprestimo de Livro Realizado com Sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPut]
        public ActionResult Update([FromBody] EmprestimoLivroDto emprestimoLivroDto)
        {
            try
            {
                if (emprestimoLivroDto == null)
                {
                    return NotFound();
                }

                _applicationServiceEmprestimoLivro.Update(emprestimoLivroDto);
                return Ok("Emprestimo de Livro Realizado com Sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
