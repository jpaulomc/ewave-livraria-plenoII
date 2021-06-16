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
    public class GeneroTest
    {
        private readonly DbContextOptions<SqlContext> _options;
        private readonly SqlContext _sqlContext;
        private readonly IRepositoryGenero _repositoryGenero;
        private readonly IServiceGenero _serviceGenero;
        private readonly IMapperGenero _mapperGenero;
        private readonly IApplicationServiceGenero _applicationServiceGenero;
        GeneroController _generoController;

        public GeneroTest()
        {
            _options = new DbContextOptionsBuilder<SqlContext>()
              .UseSqlServer(@"Data Source=.\SQLEXPRESS;Database=Livraria;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
              .Options;
            _sqlContext = new SqlContext(_options);
            _repositoryGenero = new RepositoryGenero(_sqlContext);
            _serviceGenero = new ServiceGenero(_repositoryGenero);
            _mapperGenero = new MapperGenero();
            _applicationServiceGenero = new ApplicationServiceGenero(_serviceGenero, _mapperGenero);

            _generoController = new GeneroController(_applicationServiceGenero);
        }

        [Fact]
        public void CadastrarGeneroTest()
        {
            //Arrange
            var genero = new GeneroDto() { Descricao = "Filosofia Moderna" };

            //Act
            IActionResult actionResult = _generoController.Post(genero);
            OkObjectResult okResult = actionResult as OkObjectResult;

            //Assert
            Assert.Equal(200, okResult.StatusCode);

        }

        [Fact]
        public void GetAllGeneroTest()
        {
            //Arrange
            ActionResult<IEnumerable<GeneroDto>> generos;

            //Act
            generos = _generoController.Get();
            OkObjectResult okResult = generos.Result as OkObjectResult;

            //Assert
            Assert.Equal(200, okResult.StatusCode);

        }

        [Fact]
        public void GetByIdGeneroTest()
        {
            //Arrange
            int id = 1;
            ActionResult<GeneroDto> genero;

            //Act
            genero = _generoController.Get(id);
            OkObjectResult okResult = genero.Result as OkObjectResult;

            //Assert
            Assert.Equal(200, okResult.StatusCode);

        }

        [Fact]
        public void AlterarGeneroTest()
        {
            //Arrange
            var genero = new GeneroDto() { Id = 1, Descricao = "Teologia - (Escolástica)" };

            //Act
            IActionResult actionResult = _generoController.Update(genero);
            OkObjectResult okResult = actionResult as OkObjectResult;

            //Assert
            Assert.Equal(200, okResult.StatusCode);

        }

    }
}
