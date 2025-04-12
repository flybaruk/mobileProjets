using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.models
{
    public class ResponseModel<T>
    {
        public T? Dados { get; set; }

        public string Mensagem { get; set; }
        public bool Status { get; set; }=true;
    }
}