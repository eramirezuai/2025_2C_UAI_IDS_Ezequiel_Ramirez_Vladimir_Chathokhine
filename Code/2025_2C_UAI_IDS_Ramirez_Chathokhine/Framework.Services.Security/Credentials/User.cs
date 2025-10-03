using Framework.Services.Security.Encryption;

namespace Framework.Services.Security.Credentials
{
    public class User : IUser
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public IPatent Patent { get; set; }

        public User()
        {
        }

        public static User FromPlainText(string name, string password)
        {
            var ret = new User()
            {
                Name = name,
                Password = new HashedString(password).HashedValue
            };
            return ret;
        }

        public override int GetHashCode()
        {
            return 17 * Id.GetHashCode() + 133 * Name.GetHashCode() + 771 * Password.GetHashCode();
        }
    }
}
