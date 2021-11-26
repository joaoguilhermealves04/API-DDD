using Domain.Entitidades;
using Domain.Interfacer;
using Infra.Repository.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repository.Repository
{
    public class FornecedorRepository : RepositoryBase<Fornecedor>, IFornecedorRepository
    {
        private readonly Contexto _contexto;
        public FornecedorRepository(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }
    }

}
