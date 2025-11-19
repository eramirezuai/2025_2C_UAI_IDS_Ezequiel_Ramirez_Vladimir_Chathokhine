using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public abstract class BusinessException : Exception
    {
        #region Exception codes
        // For future localization
        protected const string USER_LOGIN_ATTEMPTS_EXHAUSTED = "USER_LOGIN_ATTEMPTS_EXHAUSTED";
        protected const string USER_LOGIN_BAD_ATTEMPT = "USER_LOGIN_BAD_ATTEMPT";
        protected const string USER_LOGIN_UNKNOWN = "USER_LOGIN_UNKNOWN";
        #endregion

        public BusinessException(string message) : base(message) { }
        public BusinessException(string message, Exception baseException) : base(message, baseException) { }

        public abstract string Code { get; }
    }
}
