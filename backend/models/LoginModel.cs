using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.models
{
    public class LoginModel
    {
        public int Id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
    }
}