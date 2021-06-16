using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Mappers;
using Domain.Core.Interfaces.Services;
using System.Collections.Generic;

namespace Application
{
    public class ApplicationServiceInstituicaoEnsino : IApplicationServiceInstituicaoEnsino
    {
        private readonly IServiceInstituicaoEnsino _serviceInstituicaoEnsino;
        private readonly IMapperInstituicaoEnsino _mapperInstituicaoEnsino;
        private readonly IServiceEndereco _serviceEndereco;

        public ApplicationServiceInstituicaoEnsino(IServiceInstituicaoEnsino serviceInstituicaoEnsino, 
            IMapperInstituicaoEnsino mapperInstituicaoEnsino, IServiceEndereco serviceEndereco)
        {
            _serviceInstituicaoEnsino = serviceInstituicaoEnsino;
            _mapperInstituicaoEnsino = mapperInstituicaoEnsino;
            _serviceEndereco = serviceEndereco;
        }
        public void Add(InstituicaoEnsinoDto instituicaoEnsinoDto)
        {
            var ies = _mapperInstituicaoEnsino.MapperDtoToEntity(instituicaoEnsinoDto);
            _serviceInstituicaoEnsino.Add(ies);
        }

        public IEnumerable<InstituicaoEnsinoDto> GetAll()
        {
            var ies = _serviceInstituicaoEnsino.GetAll();
            return _mapperInstituicaoEnsino.MapperListInstituicaoEnsinosDto(ies);
        }

        public InstituicaoEnsinoDto GetById(int id)
        {
            var ies = _serviceInstituicaoEnsino.GetById(id);
            ies.Endereco = _serviceEndereco.GetById(ies.EnderecoID);
            return _mapperInstituicaoEnsino.MapperEntityToDto(ies);
        }

        public void Update(InstituicaoEnsinoDto instituicaoEnsinoDto)
        {
            var ies = _mapperInstituicaoEnsino.MapperDtoToEntity(instituicaoEnsinoDto);
            _serviceInstituicaoEnsino.Update(ies);
        }
    }
}
