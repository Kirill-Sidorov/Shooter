using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;

namespace ConsoleView
{
    public class ViewMenuConsole : ViewMenu
    {
        public ViewMenuConsole(ModelMenu parModelMenu) : base(parModelMenu)
        {
            _modelMenu.NeedRedraw += Draw;
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
            int offsetY = 5;
            ConsoleOutput.Clear();
            foreach (MenuItem item in _modelMenu.Items.Values)
            {
                DrawItem(item, offsetY);
                offsetY += 5;
            }
            ConsoleOutput.PrintOnConsole();
        }

        private void DrawItem(MenuItem parItem, int offsetY)
        {
            ConsoleColor color = ConsoleColor.Black;
            switch (parItem.CurrentStatus)
            {
                case Status.NORMAL:
                    color = ConsoleColor.White;
                    break;
                case Status.FOCUSED:
                    color = ConsoleColor.Red;
                    break;
            }
            ConsoleOutput.Write(parItem.Name, 45, offsetY, color);
        }
    }
}
