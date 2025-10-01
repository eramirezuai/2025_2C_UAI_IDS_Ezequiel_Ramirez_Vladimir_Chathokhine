using System;
using System.Collections.Generic;

namespace Framework.Services.Security.Credentials
{
    public interface IPatent
    {
        string Code { get; }

        string Description { get; }

        bool CanExecute(string codigo);

        void ForEach(Action<IPatent, IPatent> handler);

        void ForEach(Action<IPatent, IPatent> handler, IPatent padre);

        IPatent Clone();

        IEnumerable<IPatent> ChildPatents { get; }
    }
}
