using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.models;

namespace backend.services.Cabelo
{
    public interface CabeloInterface
    {
        Task<ResponseModel<List<CabeloModel>>> ListarCabelos();
        Task<ResponseModel<CabeloModel>> BuscarCabeloPorId(int idCabelo);
        Task<ResponseModel<List<CabeloModel>>> BuscarCabeloPorForma(string formaCabelo);
        
    }
}