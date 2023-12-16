using AngleSharp.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos.Streams;

namespace Module18
{
    public interface IReceiver
    {
        public void Action(Config config);
    }

    public class DecsriptionGetter : IReceiver
    { 
        public async void Action(Config myConfig) 
        {
            // Здесь будем получать описание

            #region Получение описания
            YoutubeClient youtubeClient = new();
            var videoInfo = await youtubeClient.Videos.GetAsync(myConfig.UrlVideo);
            Console.WriteLine($"Название - {videoInfo.Title}");
            Console.WriteLine($"Описание - {videoInfo.Description}");
            Console.WriteLine($"Продолжительность - {videoInfo.Duration}"); //По заданию не требуется
            #endregion Получение описания
        }
    }

    public class Downloader : IReceiver
    { 
        public async void Action(Config myConfig) 
        {
            // Здесь будем скачивать видео

            #region Скачивание
            Console.WriteLine("Начинаем скачивать");

            YoutubeClient youtubeClient = new();
            var streamManifest = await youtubeClient.Videos.Streams.GetManifestAsync(myConfig.UrlVideo); //Запрашиваю все доступные потоки (аудио и видео)

            //Получаю лучший аудиопоток формата mp4
            var audioStreamInfo = streamManifest
            .GetAudioStreams()
            .Where(s => s.Container == Container.Mp4)
            .GetWithHighestBitrate();

            //Получаю лучший видеопоток формата mp4
            var videoStreamInfo = streamManifest
            .GetVideoStreams()
            .Where(s => s.Container == Container.Mp4)
            .GetWithHighestVideoQuality();

            //Микширование аудио и видео потоков через интерфейс
            var streamInfos = new IStreamInfo[] { audioStreamInfo, videoStreamInfo };

            //Собственно скачивание мишкированного потока
            await youtubeClient.Videos.DownloadAsync(streamInfos, new ConversionRequestBuilder(string.Concat(myConfig.DownloadPath, @"\", GetSafeFilename(videoInfo.Title), ".mp4")).Build());


            Console.WriteLine("Закончили скачивать");
            #endregion Скачивание
        }

        private static string GetSafeFilename(string fileName)
        {
            return string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));
        }
    }
}
