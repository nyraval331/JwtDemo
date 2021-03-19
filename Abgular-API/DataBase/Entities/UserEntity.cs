using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Abgular_API.DataBase.Entities
{
    public class UserEntity
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string FullName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
 
    }
}
