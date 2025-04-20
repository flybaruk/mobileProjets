using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dto.CabelosTratamentos;
using backend.models;

namespace backend.services.CabeloTratamento
{
    public interface CabeloTratamentoInterface
    {
        Task<ResponseModel<List<CabeloTratamentoModel>>> ListarCabeloTratamento();
        Task<ResponseModel<List<CabeloTratamentoModel>>> ExcluirCabeloTratamento(int IdCabTrat);
        Task<ResponseModel<List<CabeloTratamentoModel>>> EditarCabeloTratamento();
        Task<ResponseModel<List<CabeloTratamentoModel>>> CriarCabeloTratamento(int IdCabelo, int IdTratamento);
        Task<ResponseModel<List<CabeloTratamentoModel>>> ListarTratamentoPorForma(string forma);
        Task<ResponseModel<List<CabeloTratamentoModel>>> ListarTratamentoPorNome(string nome);

    }
}