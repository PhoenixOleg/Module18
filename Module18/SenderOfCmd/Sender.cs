using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module18.Interfaces;

namespace Module18.SenderOfCmd
{
    /// <summary>
    /// Класс-отправитель. Через него пользователь взаимодействует с исполнительным устройством
    /// </summary>
    class Sender
    {
        private ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public async Task RunCmd()
        {
           await _command.CommandExecute();
        }
    }
}
