using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.models;

namespace backend.services.Tratamento
{
    public interface TratamentoInterface
    {
        Task<ResponseModel<List<TratamentoModel>>> ListarCabelos();
    }
}