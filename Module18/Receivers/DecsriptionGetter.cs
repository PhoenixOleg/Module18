using Module18.Interfaces;
using Module18.Utils;
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
        private readonly string _urlVideo;

        public string? Title { get; private set; }

        public DecsriptionGetter(string urlVideo)
        {
            _urlVideo = urlVideo;
        }

        public async Task ActionReceiver()
        {

            // Здесь будем получать описание

            #region Получение описания
            WriteActionMarker.Write("Получаем описание");

            YoutubeClient youtubeClient = new();
            var videoInfo = await youtubeClient.Videos.GetAsync(_urlVideo);

            Title = videoInfo.Title;
            string?_description = videoInfo.Description;
            TimeSpan?_duration = videoInfo.Duration;

            Console.WriteLine($"Название - {Title}");
            Console.WriteLine($"Описание - {_description}");
            Console.WriteLine($"Продолжительность - {_duration}"); //По заданию не требуется

            WriteActionMarker.Write("Получили описание");
            #endregion Получение описания
        }
    }
}
