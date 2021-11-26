using Domain.Entitidades;
using Domain.Interfacer;
using Infra.Repository.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repository.Repository
{
    public class EmpresaRepository : RepositoryBase<Empresa>,IEmpresaRepository
    {
        private readonly Contexto _contexto;
        public EmpresaRepository(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }
    }
}
