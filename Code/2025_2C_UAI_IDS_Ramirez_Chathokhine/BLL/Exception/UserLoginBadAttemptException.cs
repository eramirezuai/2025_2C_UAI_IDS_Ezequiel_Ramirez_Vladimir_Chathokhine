using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserLoginBadAttemptException : BusinessException
    {
        private const string _message = "Username or password not valid";

        public UserLoginBadAttemptException() : base(_message)
        {
        }

        public UserLoginBadAttemptException(Exception baseException) : base(_message, baseException)
        {
        }

        public override string Code => BusinessException.USER_LOGIN_BAD_ATTEMPT;
    }
}
