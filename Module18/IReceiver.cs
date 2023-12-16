using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module18
{
    public interface IReceiver
    {
        public void Action();
    }

    public class DecsriptionGetter : IReceiver
    { 
        public void Action() 
        { 
            // Здесь будем получать описание
        } 
    }

    public class Downloader : IReceiver
    { 
        public void Action() 
        {
            // Здесь будем скачивать видео
        }
    }
}
