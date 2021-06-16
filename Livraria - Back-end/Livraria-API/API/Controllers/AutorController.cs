using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    public class AutorController : Controller
    {
        private readonly IApplicationServiceAutor _applicationServiceAutor;

        public AutorController(IApplicationServiceAutor applicationServiceAutor)
        {
            _applicationServiceAutor = applicationServiceAutor;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AutorDto>> Get()
        {
            var listaAutor = _applicationServiceAutor.GetAll();
            var objJson = JsonConvert.SerializeObject(listaAutor);

            return Ok(objJson);
        }

        [HttpGet("{id}")]
        public ActionResult<AutorDto> Get(int id)
        {
            var autor = _applicationServiceAutor.GetById(id);
            var objJson = JsonConvert.SerializeObject(autor);
            
            return Ok(objJson);
        }

        [HttpPost]
        public ActionResult Post([FromBody] AutorDto autorDto)
        {
            try
            {
                if (autorDto == null)
                {
                    return NotFound();
                }

                _applicationServiceAutor.Add(autorDto);
                return Ok("Autor Cadastrado com Sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPut]
        public ActionResult Update([FromBody] AutorDto autorDto)
        {
            try
            {
                if (autorDto == null)
                {
                    return NotFound();
                }

                _applicationServiceAutor.Update(autorDto);
                return Ok("Autor Alterado com Sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
