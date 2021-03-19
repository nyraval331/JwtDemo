using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abgular_API.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

    }
}
