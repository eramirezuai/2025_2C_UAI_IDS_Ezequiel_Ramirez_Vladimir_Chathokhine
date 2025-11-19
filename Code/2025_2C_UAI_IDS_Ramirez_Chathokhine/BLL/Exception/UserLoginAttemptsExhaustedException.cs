using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserLoginAttemptsExhaustedException : BusinessException
    {
        private const string _message = "Maximum amount of {0} login tries exceeded";

        public UserLoginAttemptsExhaustedException(int threshold) : base(string.Format(_message, threshold))
        {
        }

        public UserLoginAttemptsExhaustedException(int threshold, Exception baseException) : base(string.Format(_message, threshold), baseException)
        {
        }

        public override string Code => BusinessException.USER_LOGIN_ATTEMPTS_EXHAUSTED;
    }
}
