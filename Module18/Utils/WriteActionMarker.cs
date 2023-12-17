using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module18.Utils
{
    internal static class WriteActionMarker
    {
        internal static void Write(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n{text}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
