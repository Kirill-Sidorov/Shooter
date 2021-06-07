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
    public class ControllerMenuConsole : ControllerMenu
    {
        public ControllerMenuConsole(ControllerMain parControllerMain, ModelMenu parModelMenu) : base(parControllerMain, parModelMenu)
        {
            _modelMenu.Items[(int)ItemCode.GAME].Selected += _controller.ChangeOnControllerGame;
            _modelMenu.Items[(int)ItemCode.RECORDS].Selected += _controller.ChangeOnControllerRecordsTable;
            _modelMenu.Items[(int)ItemCode.HELP].Selected += _controller.ChangeOnControllerHelp;
            _modelMenu.Items[(int)ItemCode.EXIT].Selected += () => { Environment.Exit(0); };
            _viewMenu = new ViewMenuConsole(_modelMenu);
        }

        public override void Start()
        {
            _viewMenu.ShowView();
            StartHandlerKeyDownMenu();
        }

        public override void Stop()
        {
            _viewMenu.CloseView(); ;
        }

        private void StartHandlerKeyDownMenu()
        {
            bool isHandleKeyDownMenu = true;
            do
            {
                ConsoleKeyInfo keyInfo = System.Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        _modelMenu.FocusNext();
                        break;
                    case ConsoleKey.UpArrow:
                        _modelMenu.FocusPrevious();
                        break;
                    case ConsoleKey.Enter:
                        isHandleKeyDownMenu = false;
                        _modelMenu.SelectFocusedItem();
                        break;
                }
            } 
            while (isHandleKeyDownMenu);
        }
    }
}
