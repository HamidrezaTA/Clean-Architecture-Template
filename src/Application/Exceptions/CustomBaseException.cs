using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class CustomBaseException : Exception
    {
        public int Status { get; set; }

        public CustomBaseException(string? message, int status) : base(message)
        {
            Status = status;
        }
    }
}