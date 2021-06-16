using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LivroController : Controller
    {
        private readonly IApplicationServiceLivro _applicationServiceLivro;
        public static IHostingEnvironment _environment;


        public LivroController(IApplicationServiceLivro applicationServiceLivro, IHostingEnvironment environment)
        {
            _applicationServiceLivro = applicationServiceLivro;
            _environment = environment;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LivroDto>> Get()
        {
            return Ok(_applicationServiceLivro.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<LivroDto> Get(int id)
        {
            return Ok(_applicationServiceLivro.GetById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] LivroDto livroDto, IFormFile file)
        {
            try
            {
                if (livroDto == null && file.Length == 0)
                {
                    return NotFound();
                }
                else
                {
                    var diretorio = _environment.WebRootPath + "\\CapaLivroImg\\";                    
                    
                    //Verificar se o diretorio de imagens já existe
                    if (!Directory.Exists(diretorio))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\CapaLivroImg\\");
                    }

                    var arquivoPath = _environment.WebRootPath + "\\CapaLivroImg\\" + file.FileName;

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
