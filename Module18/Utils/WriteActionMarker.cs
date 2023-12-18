using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module18.Utils
{
    /// <summary>
    /// Класс для вывода цветных сообщений
    /// </summary>
    internal static class WriteActionMarker
    {
        internal static void Action(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Show(text);
        }
        
        internal static void Error(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Show(text);
        }

        internal static void Info(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Show(text);
        }

        private static void Show (string text) 
        {
            Console.WriteLine($"\n{text}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
