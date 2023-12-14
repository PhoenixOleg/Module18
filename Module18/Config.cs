using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module18
{
    internal class Config
    {
        private bool _res = false;
        private string _urlVideo;
        private string _downloadPath;

        internal string UrlVideo 
        { 
          get
            {
                return _urlVideo;
            }
          set
            {
                _urlVideo = value;
                _res = false;
            }
        }

        internal string DownloadPath 
        { 
            get
            {
                return _downloadPath;
            }
            set
            {
                _downloadPath = value;
                _res = false;
            }
        }
        
        internal bool ValidatePassed 
        {
            get 
            {
                return _res;
            }
        }

        internal Config() { }

        internal Config(string UrlVideo, string DownloadPath) 
        {
            _urlVideo = UrlVideo.Trim();
            _downloadPath = DownloadPath.Trim();

            _res = Validator();
        }

        internal bool Validator()
        {
            if (string.IsNullOrEmpty(_urlVideo)) 
            {
                Console.ForegroundColor = ConsoleColor.Red; 
                Console.WriteLine("URL видео не может быть пустым");
                Console.ForegroundColor = ConsoleColor.White;

                _res = false;
            }
            else
            {
                Console.WriteLine($"URL видео для загрузки {_urlVideo}\n");
            }

            if (string.IsNullOrEmpty(_downloadPath) || !Directory.Exists(_downloadPath))
            {
                string myVideo = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Каталог для сохранения видео не может быть пустым и должен быть доступен");
                Console.ForegroundColor = ConsoleColor.White;

                _downloadPath = myVideo;
                Console.WriteLine($"Установлен каталог по-умолчанию {myVideo}\n");
                _res = true;
            }
            else
            {
                Console.WriteLine($"Каталог для сохранения видео {_downloadPath}\n");
            }

            _res = true;
            return _res;
        }
    }
}
