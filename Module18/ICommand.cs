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
        public void CommandExecute();
    }

    class GetInfoCmd : ICommand
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


    class DownloadCmd : ICommand
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
