using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.CustomExceptions
{
    public class InvalidUserNameException : Exception
    {
        public InvalidUserNameException()
        {
        }

        public InvalidUserNameException(string? message) : base(message)
        {
        }
    }
}
