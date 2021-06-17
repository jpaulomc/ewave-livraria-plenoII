using API.Controllers;
using Application;
using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Mappers;
using Application.Mappers;
using Domain.Core.Interfaces.Repositorys;
using Domain.Core.Interfaces.Services;
using Domain.Services;
using Infraestructure.Data;
using Infraestructure.Data.Repositorys;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace API.Test
{
    public class LivroTest
    {
        private readonly DbContextOptions<SqlContext> _options;
        private readonly SqlContext _sqlContext;
        private readonly IRepositoryLivro _repositoryLivro;
        private readonly IServiceLivro _serviceLivro;
        private readonly IMapperLivro _mapperLivro;
        private readonly IApplicationServiceLivro _applicationServiceLivro;
        LivroController _livroController;
             

        public LivroTest()
        {
            _options = new DbContextOptionsBuilder<SqlContext>()
              .UseSqlServer(@"Data Source=.\SQLEXPRESS;Database=Livraria;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
              .Options;
            _sqlContext = new SqlContext(_options);
            _repositoryLivro = new RepositoryLivro(_sqlContext);
            _serviceLivro = new ServiceLivro(_repositoryLivro);
            _mapperLivro = new MapperLivro();
            //_applicationServiceLivro = new ApplicationServiceLivro(_serviceLivro, _mapperLivro);
            var mockEnvironment = new Mock<IHostingEnvironment>();
            mockEnvironment.Setup(m => m.EnvironmentName).Returns("Hosting:UnitTestEnvironment");
            //_livroController = new LivroController(_applicationServiceLivro);
        }

        [Fact]
        public void CadastrarLivroTest()
        {
            //Arrange
            var file = new Mock<IFormFile>();
            var sourceImg = File.OpenRead(@"C:\Users\43474\Pictures\imgEwave.png");
            var memoryStream = new MemoryStream();
            var writer = new StreamWriter(memoryStream);
            writer.Write(sourceImg);
            writer.Flush();
            memoryStream.Position = 0;
            var fileName = "imgEwave.png";
            file.Setup(f => f.FileName).Returns(fileName).Verifiable();
            file.Setup(_ => _.CopyToAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
                .Returns((Stream stream, CancellationToken token) => memoryStream.CopyToAsync(stream))
                .Verifiable();
                        
            var inputFile = file.Object;

            var Livro = new LivroDto()
            {
                Titulo = "Suma teológica",
                Sinopse = "Um corpo de doutrina que se constitui numa das bases da dogmática do catolicismo e considerada uma das principais obras filosóficas da escolástica. " +
                "Foi escrita entre os anos de 1265 a 1273.",
                Ativo = true,
                //GeneroDto = new GeneroDto() { Id = 1, Descricao = "Teologia - (Escolástica)" },
                //AutorDto = new AutorDto() { Id = 1, Nome = "Santo Tomás de Aquino" }
            };

            //Act
            //IActionResult actionResult = _livroController.Post(Livro);
            //OkObjectResult okResult = actionResult as OkObjectResult;

            //Assert
            //Assert.Equal(200, okResult.StatusCode);

        }

        [Fact]
        public void GetAllLivroTest()
        {
            //Arrange
            ActionResult<IEnumerable<LivroDto>> Livroes;

            //Act
            Livroes = _livroController.Get();
            OkObjectResult okResult = Livroes.Result as OkObjectResult;

            //Assert
            Assert.Equal(200, okResult.StatusCode);

        }

        [Fact]
        public void GetByIdLivroTest()
        {
            //Arrange
            int id = 2;
            ActionResult<LivroDto> Livro;

            //Act
            Livro = _livroController.Get(id);
            OkObjectResult okResult = Livro.Result as OkObjectResult;

            //Assert
            Assert.Equal(200, okResult.StatusCode);

        }

        [Fact]
        public void AlterarLivroTest()
        {
            //Arrange
            //var Livro = new LivroDto() { Id = 1, Nome = "Aquino, S. Tomas " };

            //Act
            //IActionResult actionResult = _livroController.Update(Livro);
            //OkObjectResult okResult = actionResult as OkObjectResult;

            //Assert
            //Assert.Equal(200, okResult.StatusCode);

        }

    }
}
