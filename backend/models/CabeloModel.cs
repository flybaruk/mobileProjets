using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace backend.models
{
    public class CabeloModel
    {
        public int Id { get; set; }
        public string Composicao{ get; set; }
        public string Textura{ get; set; }
        public string Forma{ get; set; }

        [JsonIgnore]
        public ICollection<CabeloTratamentoModel> Tratamentos{ get; set; }
    }
}