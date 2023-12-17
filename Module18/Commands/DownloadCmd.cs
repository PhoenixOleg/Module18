using Module18.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module18.Commands
{
    internal class DownloadCmd : ICommand
    {
        IReceiver receiver;

        public DownloadCmd(IReceiver downloader)
        {
            receiver = downloader;
        }

        public void CommandExecute()
        {
            receiver.ActionReceiver();
        }
    }
}
