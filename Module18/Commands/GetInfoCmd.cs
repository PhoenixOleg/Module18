﻿using Module18.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module18.Commands
{
    internal class GetInfoCmd : ICommand
    {
        IReceiver receiver;

        public GetInfoCmd(IReceiver decsriptionGetter)
        {
            receiver = decsriptionGetter;
        }

        public void CommandExecute()
        {
            receiver.ActionReceiver();
        }
    }
}