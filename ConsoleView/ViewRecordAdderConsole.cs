using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;

namespace ConsoleView
{
    public class ViewRecordAdderConsole : ViewRecord

    {
        public ViewRecordAdderConsole(ModelRecords parModelRecords) : base(parModelRecords)
        {
        }

        public override void ShowView()
        {
            System.Console.CursorVisible = true;
            Draw();
        }

        public override void CloseView()
        {
            ConsoleOutput.Clear();
        }

        private void Draw()
        {
            ConsoleOutput.Write("Введите имя и нажмите Enter:", 35, 2, System.ConsoleColor.White);
            System.Console.SetCursorPosition(35, 9);
            ConsoleOutput.PrintOnConsole();
        }
    }
}
