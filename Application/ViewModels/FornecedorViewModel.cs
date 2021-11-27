using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels
{
    public class FornecedorViewModel
    {   
        public Guid Id { get; set; }
    
        public string Nome { get; set; }

        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
    
        public Guid EmpresaId { get; set; }   
        public EmpresaViewModels Empresa { get; set; }       
    }

    public class FornecedorPostViewModel
    {
        public Guid FornecedorId { get; set; }
        public string Nome { get; set; }

        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }

        public Guid EmpresaId { get; set; }
    }
}
