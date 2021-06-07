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
    public class ControllerRecordsTableConsole : ControllerRecordsTable
    {
        public ControllerRecordsTableConsole(ControllerMain parControllerMain, ModelRecords parModelRecords) : base(parControllerMain, parModelRecords)
        {
            _viewRecordsTable = new ViewRecordsTableConsole(_modelRecords);
        }

        public override void Start()
        {
            _viewRecordsTable.ShowView();
            StartHandlerKeyDownRecordsTable();
        }

        public override void Stop()
        {
            _viewRecordsTable.CloseView();
        }

        private void StartHandlerKeyDownRecordsTable()
        {
            bool isHandleKeyDownRecordsTable = true;
            do
            {
                ConsoleKeyInfo keyInfo = System.Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    isHandleKeyDownRecordsTable = false;
                    _controller.ChangeOnControllerMenu();
                }

            } 
            while (isHandleKeyDownRecordsTable);
        }
    }
}
