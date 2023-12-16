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

        //    Tester(myConfig);

            Console.ReadKey();

        }

        //static async void Tester(Config myConfig, IProgress<double>? progress = null)
        //{
        //    #region Тестирую библиотеку YoutubeExplode 

        //    #region Получение описания
        //    YoutubeClient youtubeClient = new YoutubeClient();
        //    var videoInfo = await youtubeClient.Videos.GetAsync(myConfig.UrlVideo);
        //    Console.WriteLine($"Название - {videoInfo.Title}");
        //    Console.WriteLine($"Описание - {videoInfo.Description}");
        //    Console.WriteLine($"Продолжительность - {videoInfo.Duration}"); //По заданию не требуется
        //    #endregion Получение описания

        //    #region Скачивание
        //    Console.WriteLine("Начинаем скачивать");
        //    var streamManifest = await youtubeClient.Videos.Streams.GetManifestAsync(myConfig.UrlVideo); //Запрашиваю все доступные потоки (аудио и видео)

        //    //Получаю лучший аудиопоток формата mp4
        //    var audioStreamInfo = streamManifest
        //    .GetAudioStreams()
        //    .Where(s => s.Container == Container.Mp4)
        //    .GetWithHighestBitrate();

        //    //Получаю лучший видеопоток формата mp4
        //    var videoStreamInfo = streamManifest
        //    .GetVideoStreams()
        //    .Where(s => s.Container == Container.Mp4)
        //    .GetWithHighestVideoQuality();

        //    //Микширование аудио и видео потоков через интерфейс
        //    var streamInfos = new IStreamInfo[] { audioStreamInfo, videoStreamInfo };
            
        //    //Собственно скачивание мишкированного потока
        //    await youtubeClient.Videos.DownloadAsync(streamInfos, new ConversionRequestBuilder(string.Concat(myConfig.DownloadPath, @"\", GetSafeFilename(videoInfo.Title), ".mp4")).Build(),  progress);


        //    Console.WriteLine("Закончили скачивать");
        //    #endregion Скачивание

        //    #endregion Тестирую библиотеку YoutubeExplode 
        //}


    }
}