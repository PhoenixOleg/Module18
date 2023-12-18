using AngleSharp.Dom;
using Module18.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Module18
{
    /// <summary>
    /// Класс хранения конфигурации параметров приложения и их окончательной валидации
    /// </summary>
    public class Config
    {
        private bool _res = false; // Внутрення переменная, хранящая состояние валидации параметров
        private string _urlVideo; //Ссылка на видео
        private string _downloadPath; //Путь для сохранения видео

        internal string UrlVideo
        {
            get => _urlVideo;
            set
            {
                _urlVideo = value;
                _res = false; //Изменили Свойство => Сбрасываем флаг валидации
            }
        }

        internal string DownloadPath
        {
            get => _downloadPath;
            set
            {
                _downloadPath = value;
                _res = false; //Изменили Свойство => Сбрасываем флаг валидации
            }
        }

        /// <summary>
        /// Свойство прохождения валидации параметров.
        /// Если свйоство ссылка на видео или путь для скачивания изменены не в конструкторе, а отдельно, ValidatePassed cтановится false
        /// Для валидации надо вызвать метод Validate
        /// 
        /// При создании класса через параметризованный конструктор, вызов валидатора происходит автоматически
        /// </summary>
        internal bool ValidatePassed 
        {
            get 
            {
                return _res; 
            }
        }

        /// <summary>
        /// Дефолтный конструтор
        /// Внимание! Свойство пути для скачивания автоматически выставляется на специальный каталог для хранения видео в профиле пользователя
        /// </summary>
        internal Config() 
        {
            _urlVideo = string.Empty;
            _downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
        }

        /// <summary>
        /// Параметризованный конструктор класса.
        /// Также вызывает метод Validate валидации принимаемых параметров
        /// </summary>
        /// <param name="UrlVideo">Ссылка на видео для скачивания</param>
        /// <param name="DownloadPath">Путь для сохранения видео</param>
        internal Config(string UrlVideo, string DownloadPath) 
        {
            _urlVideo = UrlVideo.Trim();
            _downloadPath = DownloadPath.Trim();

            _res = Validate();
        }

        /// <summary>
        /// Валидатор
        /// </summary>
        /// <returns>Возвращаемое значение. false - если ссылка на видео не прошла проверку
        /// true - если ссылка прошла проверку независимо от валидности пути для скачивани. 
        /// Внимание! При невалидном пути устанавливается каталог для хранения видео в профиле пользователя и возвращается true</returns>
        internal bool Validate()
        {
            _res = true;

            if (string.IsNullOrEmpty(_urlVideo)) 
            {
                WriteActionMarker.Error("URL видео не может быть пустым");
                _res = false;
            }

            if (!_urlVideo.Contains("youtube."))
            {
                WriteActionMarker.Error("URL не ведет на YouTube");
                _res = false;
            }
            else
            { 
                WriteActionMarker.Info($"URL видео для загрузки {_urlVideo}");
            }

            if (string.IsNullOrEmpty(_downloadPath) || !Directory.Exists(_downloadPath))
            {
                string myVideo = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);

                WriteActionMarker.Error("Каталог для сохранения видео не может быть пустым и должен быть доступен");

                _downloadPath = myVideo;
                WriteActionMarker.Info($"Установлен каталог по-умолчанию {_downloadPath}");
            }
            else
            {
                WriteActionMarker.Info($"Установлен каталог по-умолчанию {_downloadPath}");
            }
           
            return _res;
        }
    }
}
