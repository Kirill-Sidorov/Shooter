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
    public class ViewHelpConsole : ViewHelp
    {
        public ViewHelpConsole(ModelHelp parModelHelp) : base(parModelHelp)
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
            ConsoleOutput.Write(_modelHelp.Text, 1, 1, System.ConsoleColor.White);
            ConsoleOutput.PrintOnConsole();
        }
    }
}
