using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InstituicaoEnsinoController : Controller
    {
        private readonly IApplicationServiceInstituicaoEnsino _applicationServiceInstituicaoEnsino;

        public InstituicaoEnsinoController(IApplicationServiceInstituicaoEnsino applicationServiceInstituicaoEnsino)
        {
            _applicationServiceInstituicaoEnsino = applicationServiceInstituicaoEnsino;
        }

        [HttpGet]
        public ActionResult<IEnumerable<InstituicaoEnsinoDto>> Get()
        {
            var listaIes = _applicationServiceInstituicaoEnsino.GetAll();
            var objJson = JsonConvert.SerializeObject(listaIes);

            return Ok(objJson);
        }

        [HttpGet("{id}")]
        public ActionResult<InstituicaoEnsinoDto> Get(int id)
        {
            var ies = _applicationServiceInstituicaoEnsino.GetById(id);
            var objJson = JsonConvert.SerializeObject(ies);

            return Ok(ies);
        }

        [HttpPost]
        public ActionResult Post([FromBody] InstituicaoEnsinoDto instituicaoEnsinoDto)
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
