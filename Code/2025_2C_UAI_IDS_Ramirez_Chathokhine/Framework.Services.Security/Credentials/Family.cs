using System;
using System.Collections.Generic;

namespace Framework.Services.Security.Credentials
{
    public class Family : Patent
    {
        private List<IPatent> patents;

        public override long Id { get; set; }

        public override string Code { get; set; }

        public override string Description { get; set; }

        public Family(long id, string code, string description, List<IPatent> patents)
        {
            this.Id = id;
            this.Code = code;
            this.Description = description;
            this.patents = patents;
        }
        
        // For cloning purposes
        private Family(long id, string code, string description)
        {
            this.patents = new List<IPatent>();
        }
       
        public override IPatent Clone()
        {
            Family ret = new Family(Id, Code, Description);
            foreach (var patent in patents)
            {
                ret.patents.Add(patent.Clone());
            }
            return ret;
        }

        public override bool CanExecute(string code)
        {
            foreach(var patent in patents)
            {
                if (patent.CanExecute(code))
                    return true;
            }
            return false;
        }

        public void AddPatent(IPatent patent)
        {
            this.patents.Add(patent);
        }

        public void RemovePatent(IPatent patent)
        {
            this.patents.Remove(patent);
        }

        public void ClearPatents()
        {
            this.patents.Clear();
        }

        public override void ForEach(Action<IPatent, IPatent> handler, IPatent parent)
        {
            ForEach(handler, parent);
            foreach(var patent in patents)
            {
                ForEach(handler, this);
            }
        }

        public override IEnumerable<IPatent> ChildPatents
        {
            get
            {
                yield return this;
                foreach(var patent in patents)
                {
                    foreach (var p in patent.ChildPatents)
                    {
                        yield return p;
                    }
                }
            }
        }
    }
}
