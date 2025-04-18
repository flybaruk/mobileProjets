using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dto.Cabelos;
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
        [HttpGet("BuscarCabeloPorId/{idCabelo}")]
        public async Task<ActionResult<ResponseModel<CabeloModel>>> CabeloPorId(int idCabelo){
            var cabelo = await _cabeloInterface.BuscarCabeloPorId(idCabelo);
            return Ok(cabelo);
        }
        [HttpGet("BuscarCabeloPorForma/{forma}")]
        public async Task<ActionResult<ResponseModel<List<CabeloModel>>>> CabeloPorForma(string forma){
            var cabelo = await _cabeloInterface.BuscarCabeloPorForma(forma);
            return Ok(cabelo);
        }
        [HttpGet("BuscarCabeloPorTextura/{textura}")]
        public async Task<ActionResult<ResponseModel<List<CabeloModel>>>> CabeloPorTextura(string textura){
            var cabelo = await _cabeloInterface.BuscarCabeloPorForma(textura);
            return Ok(cabelo);
        }
        [HttpPost("CriarCabelo")]
        public async Task<ActionResult<ResponseModel<List<CabeloModel>>>> CriarCabelo(CabeloCriacaoDto cabeloCraicaoDto){
            var cabelo = await _cabeloInterface.CriarCabelo(cabeloCraicaoDto);
            return Ok(cabelo);
        }
        [HttpDelete("DeletarCabelo")]
        public async Task<ActionResult<ResponseModel<List<CabeloModel>>>> DeletarCabelo(int idCabelo){
            var cabelo=await _cabeloInterface.ExcluirCabelo(idCabelo);
            return Ok(cabelo);
        }

        [HttpPut("AtualizarCabelo")]
        public async Task<ActionResult<ResponseModel<List<CabeloModel>>>> EditarCabelo(CabeloEdicaoDto cabeloEdicaoDto){
            var cabelo = await _cabeloInterface.EditarCabelo(cabeloEdicaoDto);
            return Ok(cabelo);
        }
    }
}