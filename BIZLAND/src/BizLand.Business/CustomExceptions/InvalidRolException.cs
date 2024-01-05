using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.CustomExceptions
{
    public class InvalidRolException : Exception
    {
        public InvalidRolException()
        {
        }

        public InvalidRolException(string? message) : base(message)
        {
        }
    }
}
