using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReservaLivroController : Controller
    {
        private readonly IApplicationServiceReservaLivro _applicationServiceReservaLivro;

        public ReservaLivroController(IApplicationServiceReservaLivro applicationServiceReservaLivro)
        {
            _applicationServiceReservaLivro = applicationServiceReservaLivro;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceReservaLivro.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationServiceReservaLivro.GetById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] ReservaLivroDto reservaLivroDto)
        {
            try
            {
                if (reservaLivroDto == null)
                {
                    return NotFound();
                }

                _applicationServiceReservaLivro.Add(reservaLivroDto);
                return Ok("Reserva de Livro Realizada com Sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPut]
        public ActionResult Update([FromBody] ReservaLivroDto reservaLivroDto)
        {
            try
            {
                if (reservaLivroDto == null)
                {
                    return NotFound();
                }

                _applicationServiceReservaLivro.Update(reservaLivroDto);
                return Ok("Reserva de Livro Alterada com Sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
