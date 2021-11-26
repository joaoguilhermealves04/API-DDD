using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfacer
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
  
        Task<TEntity> ObterPorId(Guid id);
        Task Adicionar(TEntity entity);
        Task Atualizar(TEntity entity);
        Task<IEnumerable<TEntity>> ObterTodo();
     
    }
}
