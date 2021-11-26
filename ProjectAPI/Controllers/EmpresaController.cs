using Application.Interface;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectAPI.Controllers
{
    [Route("api/Empresa")]
    public class EmpresaController : MainController
    {
        private IEmpresaApplication _empresaApplication;
        public EmpresaController(IEmpresaApplication empresaApplication)
        {
            _empresaApplication = empresaApplication;
        }

        [HttpPost]
        public async Task< IActionResult> Adicionar([FromBody]EmpresaViewModels empresaView)
        {
            try
            {
                var result= await _empresaApplication.Adicionar(empresaView);
                return CustomResponse(result,result.Erros);
            }
            catch (Exception e)
            {
               return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] EmpresaViewModels empresaView)
        {
            try
            {
                var resul = await _empresaApplication.Atualizar(empresaView);
                return CustomResponse(resul,resul.Erros);   
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IEnumerable<EmpresaViewModels>> ObterTodos()
        {
            return (IEnumerable<EmpresaViewModels>)await _empresaApplication.ObterTodos();
        }
    }
}
