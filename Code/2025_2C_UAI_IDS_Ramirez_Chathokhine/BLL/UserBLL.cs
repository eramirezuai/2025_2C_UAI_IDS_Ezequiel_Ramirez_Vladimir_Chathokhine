using Framework.DAL;
using Framework.Services.Security.Credentials;
using Framework.Services.Security.Credentials.Data;
using Framework.Services.Security.Encryption;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBLL
    {
        private UserCrud userCrud;
        private PatentCrud patentCrud;
        private FamilyCrud familyCrud;

        public UserBLL()
        {
            userCrud = new UserCrud(new Access(), new UserParameterMapper());
            patentCrud = new PatentCrud(new Access(), new PatentParameterMapper());// TODO: crear clase PatentParameterMapper usar de base UserParameterMapper
            familyCrud = new FamilyCrud(new Access(), new FamilyParameterMapper());// TODO: crear clase FamilyParameterMapper usar de base UserParameterMapper
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

        public User CreateUser(string username, string password)
        {
            try
            {
                password = new HashedString(password).HashedValue;
                User user = new User();
                user.Name = username;
                user.Password = password;
                userCrud.Create(user);

                return user;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<User> GetAllUsers()
        {
            try
            {
                var users = userCrud.Retrieve();//new List<User>();
                List<User> listUsers = new List<User>();
                foreach (var user in users)
                {
                    listUsers.Add(user);
                }
                return listUsers;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteUser(long id)
        {
            User user = new User();
            user.Id = id;
            userCrud.Delete(user);
        }
        
        public User GetUserWithPermissions (User user)
        {


            var families = familyCrud.RetrieveByUser(user);
            var aux = new Family(0, "InternalApplicationFamily", "");
            user.Patent = aux;
            foreach (var family in families)
            {
                aux.AddPatent(GetTreeFamilies(family));
            }
            return user;
        }
        //recursive family of family
        private Family GetTreeFamilies(Family firstFamily)
        {
            var childFamilies = familyCrud.RetrieveByFamily(firstFamily);
            //se asigna la patente correspondiente a la familia procesada
            firstFamily.AddPatents(patentCrud.RetrieveByParent(firstFamily));
            if (childFamilies.Any())
            {
                foreach (var family in childFamilies)
                {
                    //asigno los hijos encontrados
                    firstFamily.AddPatent(GetTreeFamilies(family));
                    
                }

            }
            return firstFamily;
        }
    }
}

