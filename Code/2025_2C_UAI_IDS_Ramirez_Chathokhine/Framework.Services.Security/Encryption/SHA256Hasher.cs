using System;
using System.Security.Cryptography;
using System.Text;

namespace Framework.Services.Security.Encryption
{
    public class SHA256Hasher : IHasher
    {
        private SHA256 hasher;

        public SHA256Hasher()
        {
            hasher = SHA256.Create();
        }

        public string Hash(string original)
        {
            string hash = string.Empty;
            hash = BitConverter.ToString(hasher.ComputeHash(Encoding.ASCII.GetBytes(original))).ToLower().Replace("-", "");
            return hash;
        }
    }
}
