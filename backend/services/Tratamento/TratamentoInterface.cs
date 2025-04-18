using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dto.Tratamentos;
using backend.models;

namespace backend.services.Tratamento
{
    public interface TratamentoInterface
    {
        Task<ResponseModel<List<TratamentoModel>>> ListarTratamentos();
        //Task<ResponseModel<List<TratamentoModel>>> BuscarTratamentoPorId(int idTratamento);
        Task<ResponseModel<List<TratamentoModel>>> BuscarTratamentoPorBeneficio(string? Beneficio);

        Task<ResponseModel<List<TratamentoModel>>> CriarTratamento(TratamentoCriacaoDto tratamentoCriacaoDto);
        Task<ResponseModel<List<TratamentoModel>>> EditarTratamento(TratamentoEdicaoDto tratamentoEdicaoDto);
        Task<ResponseModel<List<TratamentoModel>>> ExcluirTratamento(int idTratamento);
    }
}