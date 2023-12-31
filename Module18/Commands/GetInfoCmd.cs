﻿using Module18.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module18.Commands
{
    /// <summary>
    /// Класс-команда на получение информации о видео
    /// </summary>
    internal class GetInfoCmd : ICommand
    {
        private readonly IReceiver receiver;

        public GetInfoCmd(IReceiver decsriptionGetter)
        {
            receiver = decsriptionGetter;
        }

        public async Task CommandExecute()
        {
            await receiver.ActionReceiver();
        }
    }
}
