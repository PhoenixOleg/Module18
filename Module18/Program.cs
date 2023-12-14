using YoutubeExplode;

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
            var video = await youtubeClient.Videos.GetAsync(myConfig.UrlVideo);
            Console.WriteLine($"Название - {video.Title}");
            Console.WriteLine($"Описание - {video.Description}");
            Console.WriteLine($"Продолжительность - {video.Duration}"); //По заданию не требуется
            #endregion

            #region Скачивание

            #endregion

            #endregion
        }
    }
}