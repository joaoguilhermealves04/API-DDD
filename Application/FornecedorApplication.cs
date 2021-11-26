using Application.Interface;
using Application.Status;
using Application.ViewModels;
using Domain.Entitidades;
using Domain.Interfacer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class FornecedorApplication : IFornecedorApplication
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        public FornecedorApplication(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<ServeStatus> Adicionar(FornecedorViewModels fornecedorView)
        {
            var fornecedor = new Fornecedor(fornecedorView.Nome, fornecedorView.Telefone, fornecedorView.DataNascimento);

            if (!fornecedor.ValidarEntidade().IsValid)
            {
                return await Task.FromResult(new ServeStatus(fornecedor.ValidarEntidade()
                    .Errors.Select(x => x.ErrorMessage).ToList()));

            }

            await _fornecedorRepository.Adicionar(fornecedor);
            return await Task.FromResult(new ServeStatus("Fornecedor Adicioando com Sucesso!"));

        }

        public async Task<ServeStatus> Atualizar(FornecedorViewModels fornecedorView)
        {
            var fornecedor = await _fornecedorRepository.ObterPorId(fornecedorView.Id);

            fornecedor.Atualizar(fornecedorView.Nome, fornecedorView.Telefone, fornecedorView.DataNascimento);
            if (!fornecedor.ValidarEntidade().IsValid)
            {
                return await Task.FromResult(new ServeStatus(fornecedor.ValidarEntidade()
                    .Errors.Select(x => x.ErrorMessage).ToList()));

            }

            await _fornecedorRepository.Atualizar(fornecedor);
            return await Task.FromResult(new ServeStatus("Fornecedor Atualizado com Sucesso!"));


        }

        public async Task<IEnumerable<FornecedorViewModels>> ObterTodos()
        {
            var fornecedores = await _fornecedorRepository.ObterTodo();
            var fornecedormv = new List<FornecedorViewModels>();

            foreach (var Fornecedo in fornecedores)
            {
                fornecedormv.Add(new FornecedorViewModels()
                {
                    Nome = Fornecedo.Nome,
                    DataNascimento = Fornecedo.DataNascimento,
                    Telefone = Fornecedo.Telefone,

                    Empresa = new EmpresaViewModels()
                    {
                        NomeFantasma = Fornecedo.Empresa.NomeFantasma,
                        UF = Fornecedo.Empresa.UF,
                        CNPJ = Fornecedo.Empresa.CNPJ
                    }
                });

               
            }
            return fornecedormv;
        }

        public async Task Remover(Guid id)
        {

            var fornecedor = await _fornecedorRepository.ObterPorId(id);

            fornecedor.EnviarParaLixeira();

            _fornecedorRepository.Atualizar(fornecedor);
        }
    }
}
