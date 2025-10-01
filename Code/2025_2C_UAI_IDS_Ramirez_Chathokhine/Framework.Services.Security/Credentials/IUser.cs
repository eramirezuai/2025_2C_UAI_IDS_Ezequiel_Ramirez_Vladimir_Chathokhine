namespace Framework.Services.Security.Credentials
{
    public interface IUser
    {
        string Name { get; set; }

        string Password { get; set; }

        IPatent Patent { get; }
    }
}