namespace Framework.Services.Security.Encryption
{
    public interface IEncrypter
    {
        string Desencriptar(byte[] valor);
        byte[] Encriptar(string valor);
    }
}