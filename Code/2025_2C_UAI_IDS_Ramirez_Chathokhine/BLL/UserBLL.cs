using Framework.DAL;
using Framework.Services.Security.Credentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBLL
    {
        private UserCrud userCrud;

        public UserBLL() 
        {
            userCrud = new UserCrud(new Access(), new UserParameterMapper());
        }

        public User LoginWithCredentials(string username, string password)
        {

            User user = User.FromPlainText(username, password);
            user = userCrud.RetrieveByCredentials(user);
            if (user == null) 
            {
                throw new Exception("User or password is not valid");
            }
            
            return user;
        }
    }
}

