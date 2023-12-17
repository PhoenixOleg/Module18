using Module18.Commands;
using Module18.Interfaces;
using Module18.Receivers;
using Module18.SenderOfCmd;
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

            Sender sender = new Sender(); //Сендер

            #region Вызываю команду получения инфы о видео
            DecsriptionGetter descGetter = new DecsriptionGetter(myConfig.UrlVideo); //Экземпляр Ресивера для получения инфы о видео. Оюъявляю не через интерфейс, а класс,
                                                                                     //т. к. мне нужно вызывать получение названия видео 
            sender.SetCommand(new GetInfoCmd(descGetter));
            sender.RunCmd();
            #endregion

            string title = descGetter.Title; //Название видео

            #region Вызываю команду скачивания видео
            IReceiver downloader = new Downloader(myConfig, title);

            sender.SetCommand(new DownloadCmd(downloader));
            sender.RunCmd();
            #endregion

            Console.WriteLine("Нажмите любую клавишу для выхода");
            Console.ReadKey();

        }
    }
}