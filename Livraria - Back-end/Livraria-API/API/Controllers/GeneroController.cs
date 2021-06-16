using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    public class GeneroController : Controller
    {
        private readonly IApplicationServiceGenero _applicationServiceGenero;

        public GeneroController(IApplicationServiceGenero applicationServiceGenero)
        {
            _applicationServiceGenero = applicationServiceGenero;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceGenero.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationServiceGenero.GetById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] GeneroDto generoDto)
        {
            try
            {
                if (generoDto == null)
                {
                    return NotFound();
                }

                _applicationServiceGenero.Add(generoDto);
                return Ok("Genero Cadastrado com Sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPut]
        public ActionResult Update([FromBody] GeneroDto generoDto)
        {
            try
            {
                if (generoDto == null)
                {
                    return NotFound();
                }

                _applicationServiceGenero.Update(generoDto);
                return Ok("Genero Alterado com Sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
