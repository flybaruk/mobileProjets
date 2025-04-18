using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dto.Tratamentos;
using backend.models;
using backend.services.Tratamento;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TratamentoController : ControllerBase
    {
        private readonly TratamentoInterface _tratamentoInterface;
        public TratamentoController(TratamentoInterface tratamentoInterface)
        {
            _tratamentoInterface= tratamentoInterface;
        }

        [HttpGet("ListarTratamentos")]
        public async Task<ActionResult<ResponseModel<List<TratamentoModel>>>> ListarTratamentos(){
            var tratamento = await _tratamentoInterface.ListarTratamentos();
            return Ok(tratamento);
        }

        [HttpGet("ListarTratamentos/{beneficio}")]
        public async Task<ActionResult<ResponseModel<List<TratamentoModel>>>> BuscarTratamentoPorBeneficio(string?beneficio){
            var tratamento = await _tratamentoInterface.BuscarTratamentoPorBeneficio(beneficio);
            return Ok(tratamento);
        }
        [HttpPut("AtualizarTratamento")]
        public async Task<ActionResult<ResponseModel<List<TratamentoModel>>>> EditarTratamento(TratamentoEdicaoDto tratamentoEdicaodto){
            var tratamento = await _tratamentoInterface.EditarTratamento(tratamentoEdicaodto);
            return Ok(tratamento);
        }
        [HttpPost("CriarTratamento")]
        public async Task<ActionResult<ResponseModel<List<TratamentoModel>>>> EditarTratamento(TratamentoCriacaoDto tratamentoCriacaodto){
            var tratamento = await _tratamentoInterface.CriarTratamento(tratamentoCriacaodto);
            return Ok(tratamento);
        }
        [HttpDelete("ExcluirTratamento")]
        public async Task<ActionResult<ResponseModel<List<TratamentoModel>>>> ExcluirTratamento(int idTratamento){
            var tratamento = await _tratamentoInterface.ExcluirTratamento(idTratamento);
            return Ok(tratamento);
        }
        
    }
}