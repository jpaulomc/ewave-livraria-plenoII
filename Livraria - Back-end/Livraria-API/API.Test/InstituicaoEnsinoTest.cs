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
    public class InstituicaoEnsinoTest
    {
        private readonly DbContextOptions<SqlContext> _options;
        private readonly SqlContext _sqlContext;
        private readonly IRepositoryInstituicaoEnsino _repositoryInstituicaoEnsino;
        private readonly IRepositoryEndereco _repositoryEndereco;
        private readonly IServiceInstituicaoEnsino _serviceInstituicaoEnsino;
        private readonly IServiceEndereco _serviceEndereco;
        private readonly IMapperInstituicaoEnsino _mapperInstituicaoEnsino;
        private readonly IApplicationServiceInstituicaoEnsino _applicationServiceInstituicaoEnsino;
        InstituicaoEnsinoController _instituicaoEnsinoController;

        public InstituicaoEnsinoTest()
        {
            _options = new DbContextOptionsBuilder<SqlContext>()
              .UseSqlServer(@"Data Source=.\SQLEXPRESS;Database=Livraria;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
              .Options;
            _sqlContext = new SqlContext(_options);
            _repositoryInstituicaoEnsino = new RepositoryInstituicaoEnsino(_sqlContext);
            _repositoryEndereco = new RepositoryEndereco(_sqlContext);
            _serviceEndereco = new ServiceEndereco(_repositoryEndereco);
            _serviceInstituicaoEnsino = new ServiceInstituicaoEnsino(_repositoryInstituicaoEnsino);
            _mapperInstituicaoEnsino = new MapperInstituicaoEnsino();
            _applicationServiceInstituicaoEnsino = new ApplicationServiceInstituicaoEnsino(_serviceInstituicaoEnsino, _mapperInstituicaoEnsino, _serviceEndereco);

            _instituicaoEnsinoController = new InstituicaoEnsinoController(_applicationServiceInstituicaoEnsino);
        }

        [Fact]
        public void CadastrarInstituicaoEnsinoTest()
        {
            //Arrange
            var instituicaoEnsino = new InstituicaoEnsinoDto()
            {
                Nome = "Universidade das Américas",
                EnderecoDto = new EnderecoDto() { Logradouro = "Avenida do CPA", Bairro = "Canjica", Cidade = "Cuiabá", UF = "Mato Grosso", Pais = "Brasil", CEP = "78055-725" },
                CNPJ = "15.461.552/0001-74",
                Telefone = "55 (65)3233-4546",
                Ativo = true
            };

            //Act
            IActionResult actionResult = _instituicaoEnsinoController.Post(instituicaoEnsino);
            OkObjectResult okResult = actionResult as OkObjectResult;

            //Assert
            Assert.Equal(200, okResult.StatusCode);

        }

        [Fact]
        public void GetAllInstituicaoEnsinoTest()
        {
            //Arrange
            ActionResult<IEnumerable<InstituicaoEnsinoDto>> listaInstituicaoEnsino;

            //Act
            listaInstituicaoEnsino = _instituicaoEnsinoController.Get();
            OkObjectResult okResult = listaInstituicaoEnsino.Result as OkObjectResult;

            //Assert
            Assert.Equal(200, okResult.StatusCode);

        }

        [Fact]
        public void GetByIdInstituicaoEnsinoTest()
        {
            //Arrange
            int id = 2;
            ActionResult<InstituicaoEnsinoDto> instituicaoEnsino;

            //Act
            instituicaoEnsino = _instituicaoEnsinoController.Get(id);
            OkObjectResult okResult = instituicaoEnsino.Result as OkObjectResult;

            //Assert
            Assert.Equal(200, okResult.StatusCode);

        }

        [Fact]
        public void AlterarInstituicaoEnsinoTest()
        {
            //Arrange
            var instituicaoEnsino = new InstituicaoEnsinoDto()
            {
                Id = 1,
                Nome = "Universidade da América do Sul",
                EnderecoID = 1,
                EnderecoDto = new EnderecoDto() { Id = 1, Logradouro = "Avenida Historiador Rubens de Mendonça", Bairro = "Bosque da Saúde", Cidade = "Cuiabá", UF = "Mato Grosso", Pais = "Brasil", CEP = "78050-974" },
                CNPJ = "21.683.746/0001-17",
                Telefone = "55 (65)3033-4442",
                Ativo = true
            };
            //Act
            IActionResult actionResult = _instituicaoEnsinoController.Update(instituicaoEnsino);
            OkObjectResult okResult = actionResult as OkObjectResult;

            //Assert
            Assert.Equal(200, okResult.StatusCode);

        }

    }
}
