using ConsoleController;
using Model;

namespace ConsoleApplication
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static void Main()
        {
            System.Console.WindowWidth = 100;
            System.Console.WindowHeight = 65;
            new ControllerMainConsole();
        }
    }
}
