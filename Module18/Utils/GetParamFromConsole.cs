using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module18.Utils
{
    /// <summary>
    /// Класс получения параметров работы из консоли
    /// На случай, если параметры не заданы из еомандной строки
    /// или пользователь захотел скачать более одного видео
    /// </summary>
    internal static class GetParamFromConsole
    {
        internal static void Input(Config myConfig)
        {
            bool res = true;
            while (!myConfig.ValidatePassed)
            {
                string url;
                do
                {
                    Console.Write("Введите ссылку (url) на видео, которое желаете скачать\n> ");
                    url = Console.ReadLine().Trim();
                }
                while (string.IsNullOrEmpty(url));
                myConfig.UrlVideo = url;

                Console.WriteLine("\nТекущий каталог назначения для сохранения видео " + myConfig.DownloadPath + ". Хотите его поменять? (Y/N)");
                do
                {
                    switch (Console.ReadLine().ToUpper())
                    {
                        case "Y":
                            res = false;
                            Console.Write("Введите путь для сохранения видео\n> ");
                            myConfig.DownloadPath = Console.ReadLine();
                            myConfig.Validate();
                            break;
                        case "N":
                            res = false;
                            myConfig.Validate();
                            break;
                        default:
                            Console.WriteLine("Некорректный ввод. Введите Y, чтобы изменить каталог назначения, или N, чтобы оставить без изменений");
                            break;
                    }
                }
                while (res);
            }
        }
    }
}
