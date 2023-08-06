using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Exceptions.BusinessExceptions
{
    public class NotFoundException : CustomBaseException
    {
        public NotFoundException(string message, int status) : base(message, status)
        {

        }
    }
}