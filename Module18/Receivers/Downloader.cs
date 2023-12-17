﻿using Module18.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos.Streams;
using YoutubeExplode;

namespace Module18.Receivers
{
    internal class Downloader : IReceiver
    {
        Config _myConfig;
        string _title;

        public Downloader(Config myConfig, string title)
        {
            _myConfig = myConfig;
            _title = title;
        }

        public async Task ActionReceiver()
        {
            // Здесь будем скачивать видео

            #region Скачивание
            Console.WriteLine("Начинаем скачивать");

            YoutubeClient youtubeClient = new();
            var streamManifest = youtubeClient.Videos.Streams.GetManifestAsync(_myConfig.UrlVideo); //Запрашиваю все доступные потоки (аудио и видео)

            //Получаю лучший аудиопоток формата mp4
            var audioStreamInfo = streamManifest.Result
            .GetAudioStreams()
            .Where(s => s.Container == Container.Mp4)
            .GetWithHighestBitrate();

            //Получаю лучший видеопоток формата mp4
            var videoStreamInfo = streamManifest.Result
            .GetVideoStreams()
            .Where(s => s.Container == Container.Mp4)
            .GetWithHighestVideoQuality();

            //Микширование аудио и видео потоков через интерфейс
            var streamInfos = new IStreamInfo[] { audioStreamInfo, videoStreamInfo };

            //Собственно скачивание мишкированного потока
            await youtubeClient.Videos.DownloadAsync(streamInfos, new ConversionRequestBuilder(string.Concat(_myConfig.DownloadPath, @"\", GetSafeFilename(_title), ".mp4")).Build());


            Console.WriteLine("Закончили скачивать");
            #endregion Скачивание
        }

        private static string GetSafeFilename(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                return string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));
            }
            return null;
        }
    }
}