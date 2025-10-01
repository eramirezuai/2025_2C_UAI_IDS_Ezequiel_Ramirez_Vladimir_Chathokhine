namespace Framework.Services.Security.Encryption
{
    public interface IHasher
    {
        string Hash(string original);
    }
}