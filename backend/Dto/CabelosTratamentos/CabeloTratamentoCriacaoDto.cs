using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.models;

namespace backend.Dto.CabelosTratamentos
{
    public class CabeloTratamentoCriacaoDto
    {
        public CabeloModel IdCabelo { get; set; }
        public TratamentoModel IdTratamento { get; set; }
    }
}