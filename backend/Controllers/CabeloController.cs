using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.models;
using backend.services.Cabelo;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CabeloController : ControllerBase
    {
        private readonly CabeloInterface _cabeloInterface;
        public CabeloController(CabeloInterface cabeloInterface)
        {
            _cabeloInterface= cabeloInterface;
        }

        [HttpGet("ListarCabelos")]
        public async Task<ActionResult<ResponseModel<List<CabeloModel>>>> ListarCabelos(){
            var cabelos = await _cabeloInterface.ListarCabelos();
            return Ok(cabelos);
        }
    }
}