using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Module18.Utils
{
    /// <summary>
    /// Класс прогрессбара в консоли
    /// </summary>
    internal class ConsoleProgress : IProgress<double>
    {
        private int _X; //Позиция курсора по X - столбец
        private int _Y; //Позиция курсора по y - строка
        private readonly TextWriter _writer; //Экземпляр абстрактного класс для вывода текста.
                                             //В него надо передать стандартный вывод на консоль при инициализации экземпляра прогрессбара

        private int _lastLength; //Длина последней выведенной строки. Чтобы затереть пробелами

        public ConsoleProgress(TextWriter writer)
        {
            _X = Console.CursorLeft;
            _Y = Console.CursorTop;
            _writer = writer;
        }

        /// <summary>
        /// Реализованный метод Report из интерфейса IProgress
        /// </summary>
        /// <param name="value">Значение прогресса процесса</param>
        public void Report(double value)
        {
            string _text = "";

            try
            {
                _text = "Прогресс " + ((int)(value * 100)).ToString() + "%";
            }

            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка при выводе прогресса скачивания " + ex.Message);
            }

            EraseLast();
            _writer.Write(_text);
            _lastLength = _text.Length;
        }

        /// <summary>
        /// Метод-читер. Т.к. последнее значение прогресса перед завершением может быть не 100, то для красоты отображения делаю такую заглушку
        /// Вызывать после окончания процесса
        /// </summary>
        public void FinishIt()
        {
            Report(1);
        }

        /// <summary>
        /// Очистка экрана от предыдущего вывода (затираю пробелами исходя из _lastLength - длина последней/выведенной ранее строки)
        /// </summary>
        private void EraseLast()
        {
            if (_lastLength > 0)
            {
                Console.SetCursorPosition(_X, _Y);
                _writer.Write(new string(' ', _lastLength));
                Console.SetCursorPosition(_X, _Y);
            }
        }
    }
}
