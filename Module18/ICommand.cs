using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Module18
{
    public interface ICommand
    {
        public void Execute();
    }

    class Commands : ICommand
    {
        IReceiver receiver;

        public Commands(IReceiver receiver)
        {
            this.receiver = receiver;
        }

        public void Execute()
        {
            receiver.Action();
        }
    }
}
