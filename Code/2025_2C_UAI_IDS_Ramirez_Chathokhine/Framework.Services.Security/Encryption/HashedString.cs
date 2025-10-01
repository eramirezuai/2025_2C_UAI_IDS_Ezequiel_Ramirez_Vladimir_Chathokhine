using System;

namespace Framework.Services.Security.Encryption
{
    public class HashedString
    {
        private string valorHasheado;
        private IHasher hasher;

        public HashedString(string password) : this(password, new SHA256Hasher())
        {
        }

        public HashedString(string password, IHasher hasher)
        {
            this.hasher = hasher;
            this.valorHasheado = hasher.Hash(password);
        }

        public string ValorHasheado
        {
            get { return valorHasheado; }
        }

        public override string ToString()
        {
            return ValorHasheado;
        }

        public override bool Equals(object obj)
        {
            if (obj is HashedString)
                return this.ValorHasheado.Equals(((HashedString)obj).ValorHasheado);
            else if (obj is String)
                return this.ValorHasheado.Equals(hasher.Hash((string)obj));
            else return this.Equals(obj);
        }

        public override int GetHashCode()
        {
            return valorHasheado.GetHashCode();
        }

        public static bool operator ==(HashedString hash, string valor)
        {
            return hash.Equals(valor);
        }

        public static bool operator !=(HashedString hash, string valor)
        {
            return !hash.Equals(valor);
        }

        public static bool operator ==(string value, HashedString valor)
        {
            return valor.Equals(value);
        }

        public static bool operator !=(string value, HashedString valor)
        {
            return !valor.Equals(value);
        }
    }
}
