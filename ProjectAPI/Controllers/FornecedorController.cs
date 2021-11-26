using Application.Interface;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectAPI.Controllers
{
    [Route("api/Fornecedor")]
    public class FornecedorController : MainController
    {
        private IFornecedorApplication _fornecedorApplication;
        public FornecedorController(IFornecedorApplication fornecedorApplication)
        {
            _fornecedorApplication = fornecedorApplication;
        }



        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] FornecedorViewModels fornecedorView)
        {
            try
            {
                var result = await _fornecedorApplication.Adicionar(fornecedorView);
                return CustomResponse(result, result.Erros);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] FornecedorViewModels fornecedorView)
        {
            try
            {
                var result = await _fornecedorApplication.Atualizar(fornecedorView);
                return CustomResponse(result, result.Erros);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Remover(Guid Id)
        {
            try
            {
                var result = _fornecedorApplication.Remover(Id);
                return Ok("Removido com Sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IEnumerable<FornecedorViewModels>> ObterTodos()
        {
            return await _fornecedorApplication.ObterTodos();
        }
    }
}
