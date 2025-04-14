using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dto.Cabelos;
using backend.models;

namespace backend.services.Cabelo
{
    public interface CabeloInterface
    {
        Task<ResponseModel<List<CabeloModel>>> ListarCabelos();
        Task<ResponseModel<CabeloModel>> BuscarCabeloPorId(int idCabelo);
        Task<ResponseModel<List<CabeloModel>>> BuscarCabeloPorForma(string formaCabelo);
        Task<ResponseModel<List<CabeloModel>>> BuscarCabeloPorTextura(string texturaCabelo);
        Task<ResponseModel<List<CabeloModel>>> CriarCabelo(CabeloCriacaoDto cabeloCriacaoDto);
        Task<ResponseModel<List<CabeloModel>>> ExcluirCabelo(int idCabelo);
        Task<ResponseModel<List<CabeloModel>>> EditarCabelo(CabeloEdicaoDto cabeloEdicaoDto);
        
    }
}