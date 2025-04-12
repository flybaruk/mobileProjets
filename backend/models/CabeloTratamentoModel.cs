using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.models
{
    public class CabeloTratamentoModel
    {
        public int Id { get; set;}
        public CabeloModel Cabelo { get; set; }
        public TratamentoModel Tratamento { get; set; }
    }
}