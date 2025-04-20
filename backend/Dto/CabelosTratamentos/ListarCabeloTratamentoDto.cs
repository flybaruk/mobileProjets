using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dto.CabelosTratamentos
{
    public class ListarCabeloTratamentoDto
    {
        public int IdCabelo{ get; set; }
        public string CabeloComposicao{ get; set; }
        public string CabeloTextura{ get; set; }
        public string CabeloForma{ get; set; }
        public int IdTratamento{ get; set; }
        public string TratamentoBeneficios{ get; set; }
        public string TratamentoProdutos{ get; set; }
        public string TratamentoFuncao{ get; set; }
        public string TratamentoDescritivo{get; set; }
    }
}