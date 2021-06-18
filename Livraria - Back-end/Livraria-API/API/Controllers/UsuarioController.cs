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
    public class UsuarioController : Controller
    {
        private readonly IApplicationServiceUsuario _applicationServiceUsuario;

        public UsuarioController(IApplicationServiceUsuario applicationServiceUsuario)
        {
            _applicationServiceUsuario = applicationServiceUsuario;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UsuarioDto>> Get()
        {
            var usuarios = _applicationServiceUsuario.GetAll();
            var objJson = JsonConvert.SerializeObject(usuarios);

            return Ok(objJson);
        }

        [HttpGet("{id}")]
        public ActionResult<UsuarioDto> Get(int id)
        {
            var usuario = _applicationServiceUsuario.GetById(id);
            var objJson = JsonConvert.SerializeObject(usuario);

            return Ok(objJson);
        }

        [HttpPost]
        public ActionResult Post([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                if (usuarioDto == null)
                {
                    return NotFound();
                }

                _applicationServiceUsuario.Add(usuarioDto);
                return Ok("Usuário Cadastrado com Sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public ActionResult Update([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                if (usuarioDto == null)
                {
                    return NotFound();
                }

                _applicationServiceUsuario.Update(usuarioDto);
                return Ok("Usuario Alterado com Sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
