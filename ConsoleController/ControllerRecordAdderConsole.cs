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
    public class ControllerRecordAdderConsole : ControllerRecordAdder
    {
        public ControllerRecordAdderConsole(ControllerMain parControllerMain, ModelRecords parModelRecords) : base(parControllerMain, parModelRecords)
        {
            _viewRecordAdder = new ViewRecordAdderConsole(_modelRecords);
        }

        public override void Start()
        {
            _viewRecordAdder.ShowView();
            StartHandlerKeyDownRecordAdder();
        }

        public override void Stop()
        {
            _viewRecordAdder.CloseView();
        }

        private void StartHandlerKeyDownRecordAdder()
        {
            bool isHandleKeyDownRecordAdder = true;
            do
            {
                string name = System.Console.ReadLine();
                if (name != "")
                {
                    isHandleKeyDownRecordAdder = false;
                    _modelRecords.ListRecords.Add(new Record(name, GamePoints));
                    _modelRecords.WriteToFile();
                    _controller.ChangeOnControllerMenu();
                }
            } 
            while (isHandleKeyDownRecordAdder);
        }
    }
}
