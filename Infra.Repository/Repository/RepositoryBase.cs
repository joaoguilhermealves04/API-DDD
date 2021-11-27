using Domain.Interfacer;
using Infra.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private Contexto _contexto;
        public RepositoryBase(Contexto contexto)
        {
            _contexto = contexto;
        }


        public async Task Adicionar(TEntity entity)
        {
            await _contexto.AddAsync(entity);
           _contexto.SaveChanges();
        }

        public async Task Atualizar(TEntity entity)
        {
            _contexto.Update(entity);
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
          _contexto?.Dispose();
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await _contexto.Set<TEntity>().FindAsync();
        }

        public async Task<IEnumerable<TEntity>> ObterTodo()
        {
            return await _contexto.Set<TEntity>().ToListAsync();
        }
    }
}
