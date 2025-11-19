using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    internal class UserLoginUnknownException : BusinessException
    {
        private const string _message = "Unknown error when attempting login";

        public UserLoginUnknownException(Exception baseException) : base(_message, baseException)
        {
        }

        public override string Code => BusinessException.USER_LOGIN_UNKNOWN;
    }
}
