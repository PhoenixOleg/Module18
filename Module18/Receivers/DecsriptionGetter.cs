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
    /// <summary>
    /// Класс-получатель команды получения описания видео
    /// </summary>
    internal class DecsriptionGetter : IReceiver
    {
        private readonly string _urlVideo;

        public string? Title { get; private set; }

        public DecsriptionGetter(string urlVideo)
        {
            _urlVideo = urlVideo;
        }

        /// <summary>
        /// Метод получения описания видео
        /// </summary>
        public async Task ActionReceiver()
        {

            // Здесь будем получать описание

            #region Получение описания
            WriteActionMarker.Action("Получаем описание");
            try
            { 
            YoutubeClient youtubeClient = new();
            var videoInfo = await youtubeClient.Videos.GetAsync(_urlVideo);

            Title = videoInfo.Title;
            string?_description = videoInfo.Description;
            TimeSpan?_duration = videoInfo.Duration;

            Console.WriteLine($"Название - {Title}");
            Console.WriteLine($"Описание - {_description}");
            Console.WriteLine($"Продолжительность - {_duration}"); //По заданию не требуется

            WriteActionMarker.Action("Получили описание");
            }
            catch ( Exception ex )
            {
                WriteActionMarker.Error(ex.Message);
            }
            #endregion Получение описания
        }
    }
}
