using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LivroController : Controller
    {
        private readonly IApplicationServiceLivro _applicationServiceLivro;

        public LivroController(IApplicationServiceLivro applicationServiceLivro)
        {
            _applicationServiceLivro = applicationServiceLivro;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceLivro.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationServiceLivro.GetById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] LivroDto livroDto)
        {
            try
            {
                if (livroDto == null)
                {
                    return NotFound();
                }

                _applicationServiceLivro.Add(livroDto);
                return Ok("Livro Cadastrado com Sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPut]
        public ActionResult Update([FromBody] LivroDto livroDto)
        {
            try
            {
                if (livroDto == null)
                {
                    return NotFound();
                }

                _applicationServiceLivro.Update(livroDto);
                return Ok("Livro Alterado com Sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
