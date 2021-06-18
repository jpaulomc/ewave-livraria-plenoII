using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Mappers;
using Domain.Core.Interfaces.Services;
using System.Collections.Generic;

namespace Application
{
    public class ApplicationServiceEndereco : IApplicationServiceEndereco
    {
        private readonly IServiceEndereco _serviceEndereco;
        private readonly IMapperEndereco _mapperEndereco;

        public ApplicationServiceEndereco(IServiceEndereco serviceEndereco, IMapperEndereco mapperEndereco)
        {
            _serviceEndereco = serviceEndereco;
            _mapperEndereco = mapperEndereco;
        }

        public void Add(EnderecoDto enderecoDto)
        {
            var endereco = _mapperEndereco.MapperDtoToEntity(enderecoDto);
            _serviceEndereco.Add(endereco);
        }

        public IEnumerable<EnderecoDto> GetAll()
        {
            var enderecos = _serviceEndereco.GetAll();
            return _mapperEndereco.MapperListEnderecosDto(enderecos);
        }

        public EnderecoDto GetById(int id)
        {
            var endereco = _serviceEndereco.GetById(id);
            return _mapperEndereco.MapperEntityToDto(endereco);
        }

        public void Update(EnderecoDto enderecoDto)
        {
            var endereco = _mapperEndereco.MapperDtoToEntity(enderecoDto);
            _serviceEndereco.Update(endereco);
        }
    }
}
