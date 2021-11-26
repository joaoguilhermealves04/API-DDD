using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectAPI.Controllers
{
    public class MainController : Controller
    {

        protected ActionResult CustomResponse(object result, List<string> erros)
        {
            if (erros == null)
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = erros.ToArray()
            });
        }
    }
}
