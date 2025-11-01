using System;
using System.Collections.Generic;

namespace Framework.Services.Security.Credentials
{
    public class SinglePatent : Patent
    {
        public override long Id { get; set; }

        public override string Code { get; set; }

        public override string Description { get; set; }

        public SinglePatent()
        {
        }

        public SinglePatent(long id, string code, string description)
        {
            this.Id = id;
            this.Code = code;
            this.Description = description;
        }

        public override bool CanExecute(string code)
        {
            return Code == code;
        }

        public override IPatent Clone()
        {
            return new SinglePatent(Id, Code, Description);
        }

        public override IEnumerable<IPatent> ChildPatents
        {
            get
            {
                yield return this;
            }
        }

        public override void ForEach(Action<IPatent, IPatent> handler, IPatent parent)
        {
            handler(this, parent);
        }
    }
}
