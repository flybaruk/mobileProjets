using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dto.User
{
    public class UserEditarDto
    {
        public int Id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
    }
}