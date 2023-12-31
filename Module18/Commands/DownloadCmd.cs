﻿using Module18.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module18.Commands
{
    /// <summary>
    /// Класс-команда на скачивание видео
    /// </summary>
    internal class DownloadCmd : ICommand
    {
        private readonly IReceiver receiver;

        public DownloadCmd(IReceiver downloader)
        {
            receiver = downloader;
        }

        public async Task CommandExecute()
        {
            await receiver.ActionReceiver();
        }
    }
}
