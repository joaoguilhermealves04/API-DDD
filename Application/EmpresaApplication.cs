using Application.Interface;
using Application.Status;
using Domain.Entitidades;
using Domain.Interfacer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class EmpresaApplication : IEmpresaApplication
    {
        private readonly IEmpresaRepository _empresaRepository;
        public EmpresaApplication(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public async Task<ServeStatus> Adicionar(EmpresaViewModels empresaView)
        {
            var empresa = new Empresa(empresaView.UF, empresaView.NomeFantasma, empresaView.CNPJ);

            if (!empresa.ValidarEntidade().IsValid)
            {
                return await Task.FromResult(new ServeStatus(empresa.ValidarEntidade()
                    .Errors.Select(x => x.ErrorMessage).ToList()));
            }

            await _empresaRepository.Adicionar(empresa);

            return await Task.FromResult(new ServeStatus("Empresa Adicionada com Sucesso!"));
        }

        public async Task<ServeStatus> Atualizar(EmpresaViewModels empresaView)
        {
            var empresa = await _empresaRepository.ObterPorId(empresaView.Id);

            empresa.Atualizar(empresaView.UF, empresaView.NomeFantasma, empresaView.CNPJ);

            if (!empresa.ValidarEntidade().IsValid)
            {
                return await Task.FromResult(new ServeStatus(empresa.ValidarEntidade()
                    .Errors.Select(x => x.ErrorMessage).ToList()));
            }

            await _empresaRepository.Atualizar(empresa);
            return await Task.FromResult(new ServeStatus("Empresa Atualizado com Sucesso!"));
        }

        public async Task<List<EmpresaViewModels>> ObterTodos()
        {
            var empresas = await _empresaRepository.ObterTodo();
            var empresamv = new List<EmpresaViewModels>();

            foreach (var Empresa in empresas)
            {
                empresamv.Add(new EmpresaViewModels()
                {
                    Id = Empresa.Id,
                    UF = Empresa.UF,
                    CNPJ = Empresa.CNPJ,
                    NomeFantasma = Empresa.NomeFantasma,

                });

            }
            return empresamv;
        }

        public async Task Remover(Guid id)
        {
            var empresa = await _empresaRepository.ObterPorId(id);

            empresa.EnviarParaLixeira();

            _empresaRepository.Atualizar(empresa);
        }
    }


}
