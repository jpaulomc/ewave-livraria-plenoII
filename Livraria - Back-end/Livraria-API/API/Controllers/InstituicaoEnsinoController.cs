using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    public class InstituicaoEnsinoController : Controller
    {
        private readonly IApplicationServiceInstituicaoEnsino _applicationServiceInstituicaoEnsino;

        public InstituicaoEnsinoController(IApplicationServiceInstituicaoEnsino applicationServiceInstituicaoEnsino)
        {
            _applicationServiceInstituicaoEnsino = applicationServiceInstituicaoEnsino;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceInstituicaoEnsino.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationServiceInstituicaoEnsino.GetById(id));
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] InstituicaoEnsinoDto instituicaoEnsinoDto)
        {
            try
            {
                if (instituicaoEnsinoDto == null)
                {
                    return NotFound();
                }

                _applicationServiceInstituicaoEnsino.Add(instituicaoEnsinoDto);
                return Ok("Instituição de Ensino Cadastrada com Sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public ActionResult Update([FromBody] InstituicaoEnsinoDto instituicaoEnsinoDto)
        {
            try
            {
                if (instituicaoEnsinoDto == null)
                {
                    return NotFound();
                }

                _applicationServiceInstituicaoEnsino.Update(instituicaoEnsinoDto);
                return Ok("Instituição de Ensino Alterada com Sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
