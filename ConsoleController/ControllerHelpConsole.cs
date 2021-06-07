using ConsoleView;
using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleController
{
    public class ControllerHelpConsole : ControllerHelp
    {
        public ControllerHelpConsole(ControllerMain parControllerMain, ModelHelp parModelHelp) : base(parControllerMain, parModelHelp)
        {
            _viewHelp = new ViewHelpConsole(_modelHelp);
        }

        public override void Start()
        {
            _viewHelp.ShowView();
            StartHandlerKeyDownHelp();
        }

        public override void Stop()
        {
            _viewHelp.CloseView();
        }

        private void StartHandlerKeyDownHelp()
        {
            bool isHandleKeyDownHelp = true;
            do
            {
                ConsoleKeyInfo keyInfo = System.Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    isHandleKeyDownHelp = false;
                    _controller.ChangeOnControllerMenu();
                }

            } 
            while (isHandleKeyDownHelp);
        }
    }
}
