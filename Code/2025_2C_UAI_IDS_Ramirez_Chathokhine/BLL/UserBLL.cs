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


        public User LoginWithCredentials(string username, string password)
        {

            User user = new User();
            user=userCrud.RetrieveByCredentials(username, password);
            if (user == null) 
            {
                throw new Exception("User or password is not valid");
            }
            
              return user;
        }
    }
}

