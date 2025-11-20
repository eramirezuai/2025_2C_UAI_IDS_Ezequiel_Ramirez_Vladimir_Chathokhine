using System;
using System.Collections.Generic;

namespace Framework.Services.Security.Credentials
{
    public abstract class Patent : IPatent
    {
        public abstract long Id { get; set; }
        public abstract string Code { get; set;  }
        public abstract string Description { get; set; }

        public abstract void ForEach(Action<IPatent, IPatent> handler, IPatent parent);

        public abstract bool CanExecute(string code);
        public abstract IPatent Clone();
        public abstract IEnumerable<IPatent> ChildPatents { get; } 

        public void ForEach(Action<IPatent, IPatent> handler)
        {
            ForEach(handler, null);
        }

        public override bool Equals(object obj)
        {
            if (obj is IPatent)
            {
                var patent = obj as IPatent;
                return Code == patent.Code && patent.Description == patent.Description;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return 133 * Code.GetHashCode() + 771 * Description.GetHashCode();
        }
    }
}
