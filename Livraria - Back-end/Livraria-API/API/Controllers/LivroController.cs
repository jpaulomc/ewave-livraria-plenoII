using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

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
        public ActionResult<IEnumerable<LivroDto>> Get()
        {
            var listaLivro = _applicationServiceLivro.GetAll();
            var objJson = JsonConvert.SerializeObject(listaLivro);

            return Ok(objJson);
        }

        [HttpGet("{id}")]
        public ActionResult<LivroDto> Get(int id)
        {
            var livro = _applicationServiceLivro.GetById(id);
            var objJson = JsonConvert.SerializeObject(livro);

            return Ok(objJson);
        }

        [HttpPost]
        public ActionResult Post([FromForm] LivroDto livroDto, IFormFile file)
        {
            try
            {
                
                if (livroDto == null && file.Length == 0)
                {
                    return NotFound();
                }
                else
                {
                    string path = Directory.GetCurrentDirectory();
                    var diretorio = path + "\\CapaLivroImg\\";                    
                    
                    //Verificar se o diretorio de imagens já existe
                    if (!Directory.Exists(diretorio))
                    {
                        Directory.CreateDirectory(diretorio);
                    }

                    var arquivoPath = diretorio + file.FileName;

                    using (FileStream fileStream = System.IO.File.Create(arquivoPath))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();
                        livroDto.Capa = arquivoPath;
                    }
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
