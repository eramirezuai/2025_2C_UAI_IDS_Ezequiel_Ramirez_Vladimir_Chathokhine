using BLL;
using Framework.DAL;
using Framework.Services.Security;
using Framework.Services.Security.Credentials;
using Framework.Services.Security.Encryption;
using System;

namespace BLL
{
    public class UserBLL
    {
        private UserCrud userCrud;
        private int badLoginCount;
        private int badLoginThreshold;

        public UserBLL() 
        {
            userCrud = new UserCrud(new Access(), new UserParameterMapper());
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
                User user = new User();
                user.Name = username;
                user.Password = password;
                userCrud.Create(user);

                return user;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}

