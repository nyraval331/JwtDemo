using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abgular_API.DataTransferObjects
{
    public class AuditActionResult<T>
    {
        public List<ErrorMessage> ErrorMessages { get; set; }
        public T Object { get; set; }

        public AuditActionResult()
        {
            ErrorMessages = new List<ErrorMessage>();
        }

        public bool HasErrors
        {
            get
            {
                return ErrorMessages.Any();
            }
        }
    }
}
