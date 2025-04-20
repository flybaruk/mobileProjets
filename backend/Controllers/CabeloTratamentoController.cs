using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using backend.Dto.CabelosTratamentos;
using backend.models;
using backend.services.CabeloTratamento;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CabeloTratamentoController : ControllerBase
    {
        private readonly CabeloTratamentoInterface _cabeleTratamentoInterface;
        public CabeloTratamentoController(CabeloTratamentoInterface cabeloTratamentoInterface)
        {
            _cabeleTratamentoInterface= cabeloTratamentoInterface;
        }
        [HttpGet("ListarTudo")]
        public async Task<ActionResult<ResponseModel<List<CabeloTratamentoModel>>>> ListarTudo(){
            var cabeloTratamento = await _cabeleTratamentoInterface.ListarCabeloTratamento();
            return Ok(cabeloTratamento);
        }

        [HttpGet("ListarTudo/{forma}")]
        public async Task<ActionResult<ResponseModel<List<CabeloTratamentoModel>>>> ListarTratamentoPorForma(string forma){
            var cabeloTratamento = await _cabeleTratamentoInterface.ListarTratamentoPorForma(forma);
            return Ok(cabeloTratamento); 
        }
        [HttpPost("VincularTratamentoToCabelo")]
        public async Task<ActionResult<ResponseModel<List<CabeloTratamentoModel>>>> VincularTratamentoToCabelo(int IdCabelo, int IdTratamento){
            var cabeloTratamento = await _cabeleTratamentoInterface.CriarCabeloTratamento(IdCabelo, IdTratamento);
            return Ok(cabeloTratamento); 
        }
        [HttpDelete("DesvincularCabeloComTratamento")]
        public async Task<ActionResult<ResponseModel<List<CabeloTratamentoModel>>>> DesvincularTratamentoToCabelo(int Id){
            var cabeloTratamento = await _cabeleTratamentoInterface.ExcluirCabeloTratamento(Id);
            return Ok(cabeloTratamento); 
        }
    }
}