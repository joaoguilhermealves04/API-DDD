using Application.Status;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IFornecedorApplication
    {
        Task<ServeStatus> Adicionar(FornecedorPostViewModel fornecedorView);
        Task<ServeStatus> Atualizar(FornecedorPostViewModel fornecedorView);
        Task Remover(Guid id);
        Task<IEnumerable<FornecedorViewModel>> ObterTodos();
    }
}
