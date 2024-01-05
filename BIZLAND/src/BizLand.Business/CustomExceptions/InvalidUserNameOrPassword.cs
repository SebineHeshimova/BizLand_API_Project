using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.CustomExceptions
{
    public class InvalidUserNameOrPassword : Exception
    {
        public InvalidUserNameOrPassword()
        {
        }

        public InvalidUserNameOrPassword(string? message) : base(message)
        {
        }
    }
}
