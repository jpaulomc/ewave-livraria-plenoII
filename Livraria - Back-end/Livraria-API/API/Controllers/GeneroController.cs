using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public ActionResult<IEnumerable<GeneroDto>> Get()
        {
            var listaGenero = _applicationServiceGenero.GetAll();
            var objJson = JsonConvert.SerializeObject(listaGenero);

            return Ok(objJson);
        }

        [HttpGet("{id}")]
        public ActionResult<GeneroDto> Get(int id)
        {
            var genero = _applicationServiceGenero.GetById(id);
            var objJson = JsonConvert.SerializeObject(genero);

            return Ok(objJson);
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
                return Ok("Gênero Cadastrado com Sucesso!");
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
                return Ok("Gênero Alterado com Sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
