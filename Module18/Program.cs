namespace Module18
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            Console.ReadKey();

        }
    }
}