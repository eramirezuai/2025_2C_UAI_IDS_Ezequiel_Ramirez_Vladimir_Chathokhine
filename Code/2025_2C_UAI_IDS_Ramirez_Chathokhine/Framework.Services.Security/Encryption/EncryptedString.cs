
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Services.Security.Encryption
{
    public class EncryptedString
    {
        private string valorEncriptado;
        private string valorDesencriptado;
        private IEncrypter encriptador;

        public EncryptedString(string valor, string password) : this(valor, password, new DES3DESEncrypter(password))
        {
        }

        public EncryptedString(string valor, string password, IEncrypter encriptador)
        {
            this.encriptador = encriptador;
            this.valorDesencriptado = valor;
            this.valorEncriptado = Encoding.UTF8.GetString(encriptador.Encriptar(password));
        }

        public string ValorEncriptado
        {
            get { return valorEncriptado; }
        }

        public string ValorDesencriptado
        {
            get { return valorDesencriptado; }
        }

        public override string ToString()
        {
            return ValorEncriptado;
        }

        public override bool Equals(object obj)
        {
            if (obj is EncryptedString)
                return this.ValorEncriptado.Equals(((EncryptedString)obj).ValorEncriptado);
            else if (obj is String)
                return this.valorDesencriptado.Equals((string)obj);
            else return this.Equals(obj);
        }

        public override int GetHashCode()
        {
            return ValorEncriptado.GetHashCode();
        }
    }
}
