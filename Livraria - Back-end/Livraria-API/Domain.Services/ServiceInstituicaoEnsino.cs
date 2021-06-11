using Domain.Core.Interfaces.Repositorys;
using Domain.Core.Interfaces.Services;
using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public class ServiceInstituicaoEnsino : ServiceBase<InstituicaoEnsino>, IServiceInstituicaoEnsino
    {
        private readonly IRepositoryInstituicaoEnsino _repositoryInstituicaoEnsino;

        public ServiceInstituicaoEnsino(IRepositoryInstituicaoEnsino repositoryInstituicaoEnsino) : base(repositoryInstituicaoEnsino)
        {
            _repositoryInstituicaoEnsino = repositoryInstituicaoEnsino;
        }
    }
}
