using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dto.Cabelos
{
    public class CabeloEdicaoDto
    {
        public int Id { get; set; }
        public string Composicao{ get; set; }
        public string Textura{ get; set; }
        public string Forma{ get; set; }
    }
}