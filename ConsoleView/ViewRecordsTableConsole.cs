using Model;
using System;
using View;

namespace ConsoleView
{
    public class ViewRecordsTableConsole : ViewRecord
    {
        public ViewRecordsTableConsole(ModelRecords parModelRecords) : base(parModelRecords)
        {
        }

        public override void ShowView()
        {
            System.Console.CursorVisible = false;
            Draw();
        }

        public override void CloseView()
        {
            ConsoleOutput.Clear();
        }

        private void Draw()
        {
            int offsetY = 1;
            ConsoleOutput.Write("Игрок", 30, offsetY, System.ConsoleColor.Red);
            ConsoleOutput.Write("Очки", 60, offsetY, System.ConsoleColor.Red);
            foreach (Record record in _modelRecords.ListRecords)
            {
                offsetY += 1;
                ConsoleOutput.Write(record.Name, 30, offsetY, System.ConsoleColor.White);
                ConsoleOutput.Write(String.Format("{0,-5:D}", record.Score), 60, offsetY, System.ConsoleColor.White);
            }
            ConsoleOutput.PrintOnConsole();
        }
    }
}
