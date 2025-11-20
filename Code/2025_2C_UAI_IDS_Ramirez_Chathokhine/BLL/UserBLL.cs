using BLL;
using Framework.DAL;
using Framework.Services.Security;
using Framework.Services.Security.Credentials;
using Framework.Services.Security.Credentials.Data;
using Framework.Services.Security.Encryption;
using Framework.Services.Security.Log;
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
        private int badLoginCount;
        private int badLoginThreshold;
        private IDataLog dataLog;

        public UserBLL()
        {
            userCrud = new UserCrud(new Access(), new UserParameterMapper());
            patentCrud = new PatentCrud(new Access(), new PatentParameterMapper());
            familyCrud = new FamilyCrud(new Access(), new FamilyParameterMapper());
            // TODO: replace with injection 
            dataLog = new DataLog
            (
                new DatabaseLogReader
                (
                    new DataLogLoginCrud(new Access(), new DataLogLoginParameterMapper()),
                    new DataLogDatabaseCrud(new Access(), new DataLogDatabaseParameterMapper())
                ), 
                new DatabaseLogWriter
                (
                    new DataLogLoginCrud(new Access(), new DataLogLoginParameterMapper()),
                    new DataLogDatabaseCrud(new Access(), new DataLogDatabaseParameterMapper())
                )
            );
            badLoginCount = 0;
            // TODO: make it configurable
            badLoginThreshold = 3;
        }

        public IUser LoginWithCredentials(string username, string password)
        {
            try
            {
                var encryptedUser = User.FromPlainText(username, password);
                password = new HashedString(password).HashedValue;
                if (!Session.OpenWith(encryptedUser, SessionFactory.CreateUserRetrieverByCredentials()))
                {
                    if (badLoginCount == badLoginThreshold)
                    {
                        throw new UserLoginAttemptsExhaustedException(badLoginThreshold);
                    }
                    badLoginCount++;
                    throw new UserLoginBadAttemptException();
                }
                return Session.Current.User;
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new UserLoginUnknownException(ex);
            }
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

