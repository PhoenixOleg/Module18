using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module18.Interfaces;

namespace Module18.SenderOfCmd
{
    class Sender
    {
        ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public async Task /*void*/ RunCmd()
        {
           await _command.CommandExecute();
        }
    }
}
