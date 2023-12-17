using Module18.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;

namespace Module18.Receivers
{
    internal class DecsriptionGetter : IReceiver
    {
        private string _urlVideo;

        private string? _title;
        private string? _description;
        private TimeSpan? _duration;

        public string Title
        {
            get
            {
                return _title;
            }
        }

        public DecsriptionGetter(string urlVideo)
        {
            _urlVideo = urlVideo;
        }

        public async Task ActionReceiver()
        {

            // Здесь будем получать описание

            #region Получение описания
            Console.WriteLine("Получаем описание");
            YoutubeClient youtubeClient = new();
            var videoInfo = youtubeClient.Videos.GetAsync(_urlVideo);

            _title = videoInfo.Result.Title;
            _description = videoInfo.Result.Description;
            _duration = (TimeSpan)videoInfo.Result.Duration;

            Console.WriteLine($"Название - {_title}");
            Console.WriteLine($"Описание - {_description}");
            Console.WriteLine($"Продолжительность - {_duration}"); //По заданию не требуется
            Console.WriteLine("Получили описание");
            #endregion Получение описания
        }
    }
}
