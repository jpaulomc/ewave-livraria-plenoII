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
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace API.Test
{
    public class AutorTest
    {
        private readonly DbContextOptions<SqlContext> _options;
        private readonly SqlContext _sqlContext;
        private readonly IRepositoryAutor _repositoryAutor;
        private readonly IServiceAutor _serviceAutor;
        private readonly IMapperAutor _mapperAutor;
        private readonly IApplicationServiceAutor _applicationServiceAutor;
        AutorController _autorController;

        public AutorTest()
        {
            _options = new DbContextOptionsBuilder<SqlContext>()
              .UseSqlServer(@"Data Source=.\SQLEXPRESS;Database=Livraria;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
              .Options;
            _sqlContext = new SqlContext(_options);
            _repositoryAutor = new RepositoryAutor(_sqlContext);
            _serviceAutor = new ServiceAutor(_repositoryAutor);
            _mapperAutor = new MapperAutor();
            _applicationServiceAutor = new ApplicationServiceAutor(_serviceAutor, _mapperAutor);

            _autorController = new AutorController(_applicationServiceAutor);
        }

        [Fact]
        public void CadastrarAutorTest()
        {
            //Arrange
            var autor = new AutorDto() { Nome = "Olavo de Carvalho" };

            //Act
            IActionResult actionResult = _autorController.Post(autor);
            OkObjectResult okResult = actionResult as OkObjectResult;

            //Assert
            Assert.Equal(200, okResult.StatusCode);

        }

        [Fact]
        public void GetAllAutorTest()
        {
            //Arrange
            ActionResult<IEnumerable<AutorDto>> autores;

            //Act
            autores = _autorController.Get();
            OkObjectResult okResult = autores.Result as OkObjectResult;

            //Assert
            Assert.Equal(200, okResult.StatusCode);

        }

        [Fact]
        public void GetByIdAutorTest()
        {
            //Arrange
            int id = 2;
            ActionResult<AutorDto> autor;

            //Act
            autor = _autorController.Get(id);
            OkObjectResult okResult = autor.Result as OkObjectResult;

            //Assert
            Assert.Equal(200, okResult.StatusCode);

        }

        [Fact]
        public void AlterarAutorTest()
        {
            //Arrange
            var autor = new AutorDto() { Id = 1, Nome = "Aquino, S. Tomas " };

            //Act
            IActionResult actionResult = _autorController.Update(autor);
            OkObjectResult okResult = actionResult as OkObjectResult;

            //Assert
            Assert.Equal(200, okResult.StatusCode);

        }

    }
}
