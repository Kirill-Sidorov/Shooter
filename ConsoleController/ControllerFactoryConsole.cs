using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleController
{
    public class ControllerFactoryConsole : ControllerFactory
    {
        public ControllerFactoryConsole(ControllerMain parControllerMain) : base(parControllerMain)
        {
        }

        public override ControllerCommon CreateControllerGame()
        {
            ControllerGameConsole controller = new ControllerGameConsole(_controller, ModelGame.GetInstance());
            return controller;
        }

        public override ControllerCommon CreateControllerHelp()
        {
            ControllerHelpConsole controller = new ControllerHelpConsole(_controller, new ModelHelp());
            return controller;
        }

        public override ControllerCommon CreateControllerMenu()
        {
            ControllerMenuConsole controller = new ControllerMenuConsole(_controller, new ModelMenu());
            return controller;
        }

        public override ControllerCommon CreateControllerRecordAdder()
        {
            if (_modelRecords == null)
            {
                _modelRecords = new ModelRecords();
            }
            ControllerRecordAdderConsole controller = new ControllerRecordAdderConsole(_controller, _modelRecords);
            return controller;
        }

        public override ControllerCommon CreateControllerRecordsTable()
        {
            if (_modelRecords == null)
            {
                _modelRecords = new ModelRecords();
            }
            ControllerRecordsTableConsole controller = new ControllerRecordsTableConsole(_controller, _modelRecords);
            return controller;
        }
    }
}
