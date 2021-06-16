using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceAutor.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationServiceAutor.GetById(id));
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
        public ActionResult Update([FromBody] AutorDto AutorDto)
        {
            try
            {
                if (AutorDto == null)
                {
                    return NotFound();
                }

                _applicationServiceAutor.Update(AutorDto);
                return Ok("Autor Alterado com Sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
