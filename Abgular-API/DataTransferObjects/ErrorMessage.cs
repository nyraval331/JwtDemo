using Abgular_API.DataTransferObjects.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abgular_API.DataTransferObjects
{
    public class ErrorMessage
    {
        public ErrorTypes ErrorType { get; set; }
        public string Message { get; set; }

        public ErrorMessage(ErrorTypes errorType, string message)
        {
            ErrorType = errorType;
            Message = message;
        }
    }
}
