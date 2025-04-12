using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace backend.models
{
    public class TratamentoModel
    {
        public int Id{ get; set; }
        public string Beneficios{ get; set; }
        public string Produtos{ get; set; }
        public string Funcao{ get; set; }
        public string Descritivo{get; set; }

        [JsonIgnore]
        public ICollection<CabeloTratamentoModel> Cabelos{ get; set; }
    }
}