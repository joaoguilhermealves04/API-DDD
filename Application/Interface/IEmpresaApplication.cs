using Application.Status;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IEmpresaApplication
    {
        Task<ServeStatus> Adicionar(EmpresaViewModels empresaView);
        Task<ServeStatus> Atualizar(EmpresaViewModels empresaView);
        Task Remover(Guid id);
        Task<List<EmpresaViewModels>> ObterTodos();

    }
}
