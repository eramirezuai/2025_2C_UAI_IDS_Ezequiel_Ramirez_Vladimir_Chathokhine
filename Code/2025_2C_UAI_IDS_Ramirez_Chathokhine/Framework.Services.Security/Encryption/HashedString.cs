using System;

namespace Framework.Services.Security.Encryption
{
    public class HashedString
    {
        private string hashedValue;
        private IHasher hasher;

        public HashedString(string password) : this(password, new SHA256Hasher())
        {
        }

        public HashedString(string password, IHasher hasher)
        {
            this.hasher = hasher;
            this.hashedValue = hasher.Hash(password);
        }

        public string HashedValue
        {
            get { return hashedValue; }
        }

        public override string ToString()
        {
            return HashedValue;
        }

        public override bool Equals(object obj)
        {
            if (obj is HashedString)
                return this.HashedValue.Equals(((HashedString)obj).HashedValue);
            else if (obj is String)
                return this.HashedValue.Equals(hasher.Hash((string)obj));
            else return this.Equals(obj);
        }

        public override int GetHashCode()
        {
            return hashedValue.GetHashCode();
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
