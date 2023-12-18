using AngleSharp.Dom;
using Module18.Commands;
using Module18.Interfaces;
using Module18.Receivers;
using Module18.SenderOfCmd;
using Module18.Utils;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos.Streams;

namespace Module18
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            #region Чтение и проверка параметров командной строки
            Config myConfig = new();

            if (args.Length != 2)
            {
                Console.WriteLine("Не заданы или некорректно заданы аргументы командной строки. Ничего страшного! Сейчас все запросим");
            }
            else
            {
                myConfig = new(args[0], args[1]);
            }
            #endregion

            bool res = true;
            do
            {
                GetParamFromConsole.Input(myConfig);


                Sender sender = new(); //Сендер

                #region Вызываю команду получения инфы о видео
                DecsriptionGetter descGetter = new(myConfig.UrlVideo); //Экземпляр Ресивера для получения инфы о видео. Оюъявляю не через интерфейс, а класс,
                                                                       //т. к. мне нужно вызывать получение названия видео 
                sender.SetCommand(new GetInfoCmd(descGetter));
                await sender.RunCmd();
                #endregion

                string? title = descGetter.Title; //Название видео

                #region Вызываю команду скачивания видео
                IReceiver downloader = new Downloader(myConfig, title);

                sender.SetCommand(new DownloadCmd(downloader));
                await sender.RunCmd();
                #endregion

                Console.WriteLine("Желаете скачать еще одно видео? (Y/N)");

                bool resRetry = true;
                do
                {
                    switch (Console.ReadLine().ToUpper())
                    {
                        case "Y":
                            myConfig.UrlVideo = string.Empty;
                            resRetry = false;
                            res = true;
                            break;
                        case "N":
                            resRetry = false;
                            res = false;
                            break;
                        default:
                            Console.WriteLine("Некорректный ввод. Введите Y для скачивание еще одного видео или N, чтобы завершить работу");
                            break;
                    }
                } while (resRetry);
            }
            while (res);
        }
    }
}