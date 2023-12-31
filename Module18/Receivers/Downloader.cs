﻿using Module18.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos.Streams;
using YoutubeExplode;
using Module18.Utils;

namespace Module18.Receivers
{
    /// <summary>
    /// Класс-получатель команды на скачивание
    /// </summary>
    internal class Downloader : IReceiver
    {
        private readonly Config _myConfig;
        private readonly string? _title;

        public Downloader(Config myConfig, string? title)
        {
            _myConfig = myConfig;
            _title = title;
        }

        /// <summary>
        /// Метод скачивания видео
        /// </summary>
        public async Task ActionReceiver()
        {
            // Здесь будем скачивать видео

            #region Скачивание
            WriteActionMarker.Action("Начинаем скачивать");

            try
            { 
            YoutubeClient youtubeClient = new();
            var streamManifest = await youtubeClient.Videos.Streams.GetManifestAsync(_myConfig.UrlVideo); //Запрашиваю все доступные потоки (аудио и видео)

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

            //Собственно скачивание мишкированного потока с прогресс баром
            var progress = new ConsoleProgress(Console.Out);

            await youtubeClient.Videos.DownloadAsync(streamInfos, new ConversionRequestBuilder(Path.Combine(_myConfig.DownloadPath, string.Concat(GetSafeFilename(_title), ".mp4"))).Build(), progress);

            progress.FinishIt();

            WriteActionMarker.Action("Закончили скачивать");
            }
            catch (Exception ex)
            {
                WriteActionMarker.Error(ex.Message);
            }
            #endregion Скачивание
        }

        private static string GetSafeFilename(string? fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                return string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));
            }
            return "NoName";
        }
    }
}