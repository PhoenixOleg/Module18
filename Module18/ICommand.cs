using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Module18
{
    public interface ICommand
    {
        public void Execute(Config config);
    }

    class Commands : ICommand
    {
        readonly IReceiver receiver;

        public Commands(IReceiver receiver)
        {
            this.receiver = receiver;
        }

        public void Execute(Config config)
        {
            receiver.Action(config);
        }
    }
}
