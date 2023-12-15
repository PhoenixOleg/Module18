using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos.Streams;

namespace Module18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Чтение и проверка параметров командной строки
            Config myConfig = new();

            if (args.Length != 2) 
            {
                Console.WriteLine("Некорректно заданы аргументы командной строки");
            }
            else
            {
                myConfig = new(args[0], args[1]);
            }
        
            if (myConfig.ValidatePassed == false)
            {
                Console.WriteLine("Некорректно заданы параметры работы приложения");
            }
            #endregion

            Tester(myConfig);

            Console.ReadKey();

        }

        static async void Tester(Config myConfig)
        {
            #region Тестирую библиотеку YoutubeExplode 

            #region Получение описания
            YoutubeClient youtubeClient = new YoutubeClient();
            var videoInfo = await youtubeClient.Videos.GetAsync(myConfig.UrlVideo);
            Console.WriteLine($"Название - {videoInfo.Title}");
            Console.WriteLine($"Описание - {videoInfo.Description}");
            Console.WriteLine($"Продолжительность - {videoInfo.Duration}"); //По заданию не требуется
            #endregion

            #region Скачивание
            Console.WriteLine("Начинаем скачивать");
            var streamManifest = await youtubeClient.Videos.Streams.GetManifestAsync(myConfig.UrlVideo); //Запрашиваю все доступные потоки (аудио и видео)
            var streamInfo = streamManifest.Streams; //Получил потоки
            //var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestBitrate(); // Получаю смешанный поток с максимальным битрейтом

            // Получение актального потока
            //var stream = await youtubeClient.Videos.Streams.GetAsync(streamInfo);
            // Скачивание потока в файл
            //await youtubeClient.Videos.Streams.DownloadAsync(streamInfo, string.Concat(myConfig.DownloadPath, @$"\video.{streamInfo.Container}"));

            //Скачивание видео в файл. Походу выбираем сам лучшие потоки
            //await youtubeClient.Videos.DownloadAsync(myConfig.UrlVideo, string.Concat(myConfig.DownloadPath, @"\video.mp4"));


            var audioStreamInfo = streamManifest
            .GetAudioStreams()
            .Where(s => s.Container == Container.Mp4)
            .GetWithHighestBitrate();

            var videoStreamInfo = streamManifest
            .GetVideoStreams()
            .Where(s => s.Container == Container.Mp4)
            .GetWithHighestVideoQuality();

            var streamInfos = new IStreamInfo[] { audioStreamInfo, videoStreamInfo };
            await youtubeClient.Videos.DownloadAsync(streamInfos, new ConversionRequestBuilder(string.Concat(myConfig.DownloadPath, @"\video.mp4")).Build());
            await youtubeClient.Videos.DownloadAsync(streamInfos, new ConversionRequestBuilder(string.Concat(myConfig.DownloadPath, @"\" + GetSafeFilename(videoInfo.Title) + ".mp4")).Build());

            Console.WriteLine("Закончили скачивать");
            #endregion

            #endregion
        }

        public static string GetSafeFilename(string fileName)
        {
            return string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));
        }
    }
}