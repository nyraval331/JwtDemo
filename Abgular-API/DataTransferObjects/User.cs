using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abgular_API.DataTransferObjects
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
