using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsController
{
    public class ControllerFactoryWindow : ControllerFactory
    {
        public ControllerFactoryWindow(ControllerMain parControllerMain) : base(parControllerMain)
        {
        }

        public override ControllerCommon CreateControllerGame()
        {
            ControllerGameWindow controller = new ControllerGameWindow(_controller, ModelGame.GetInstance());
            return controller;
        }

        public override ControllerCommon CreateControllerHelp()
        {
            ControllerHelpWindow controller = new ControllerHelpWindow(_controller, new ModelHelp());
            return controller;
        }

        public override ControllerCommon CreateControllerMenu()
        {
            ControllerMenuWindow controller = new ControllerMenuWindow(_controller, new ModelMenu());
            return controller;
        }

        public override ControllerCommon CreateControllerRecordAdder()
        {
            if (_modelRecords == null)
            {
                _modelRecords = new ModelRecords();
            }
            ControllerRecordAdderWindow controller = new ControllerRecordAdderWindow(_controller, _modelRecords);
            return controller;
        }

        public override ControllerCommon CreateControllerRecordsTable()
        {
            if (_modelRecords == null)
            {
                _modelRecords = new ModelRecords();
            }
            ControllerRecordsTableWindow controller = new ControllerRecordsTableWindow(_controller, _modelRecords);
            return controller;
        }
    }
}
