using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Services.Security.Encryption
{
    public class DES3DESEncrypter : IEncrypter
    {
        private byte[] passwordBytes;
        private byte[] IVBytes;

        private static byte[] DefaultIV => new byte[] {0x03, 0xA6, 0x50, 0x8C, 0x5F, 0xA5, 0x8C, 0x94};
        
        public DES3DESEncrypter(string password) : this(Encoding.UTF8.GetBytes(password), DefaultIV)
        {
        }


        public DES3DESEncrypter(string password, string IV) : this(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(IV))
        {
        }

        public DES3DESEncrypter(byte[] password, byte[] IV)
        {
            this.passwordBytes = password;
            this.IVBytes = IV;
        }

        public byte[] Encriptar(string valor)
        {
            var bytesValue = Encoding.UTF8.GetBytes(valor);
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            provider.BlockSize = passwordBytes.Length * 8;
            provider.Key = passwordBytes;
            provider.IV = IVBytes;
            ICryptoTransform transform = provider.CreateDecryptor();
            CryptoStreamMode mode = CryptoStreamMode.Write;
            MemoryStream memStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memStream, transform, mode);
            cryptoStream.Write(bytesValue, 0, bytesValue.Length);
            cryptoStream.FlushFinalBlock();
            byte[] encryptedMessageBytes = new byte[memStream.Length -1];
            memStream.Position = 0;
            memStream.Read(encryptedMessageBytes, 0, encryptedMessageBytes.Length);
            return encryptedMessageBytes;
        }

        public string Desencriptar(byte[] valor)
        {
            var bytesValue = valor;
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            provider.BlockSize = passwordBytes.Length * 8;
            provider.Key = passwordBytes;
            provider.IV = IVBytes;
            ICryptoTransform transform = provider.CreateEncryptor();
            CryptoStreamMode mode = CryptoStreamMode.Write;
            MemoryStream memStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memStream, transform, mode);
            cryptoStream.Write(bytesValue, 0, bytesValue.Length);
            cryptoStream.FlushFinalBlock();
            byte[] decryptedMessageBytes = new byte[memStream.Length - 1];
            memStream.Position = 0;
            memStream.Read(decryptedMessageBytes, 0, decryptedMessageBytes.Length);
            return Encoding.UTF8.GetString(decryptedMessageBytes);
        }
    }
}
