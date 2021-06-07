using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsController
{
    public class ControllerMainWindow : ControllerMain
    {
        public ControllerMainWindow()
        {
            ControllerFactoryWindow factory = new ControllerFactoryWindow(this);
            _controllerGame = factory.CreateControllerGame();
            _controllerMenu = factory.CreateControllerMenu();
            _controllerHelp = factory.CreateControllerHelp();
            _controllerRecordAdder = factory.CreateControllerRecordAdder();
            _controllerRecordsTable = factory.CreateControllerRecordsTable();

            _currentController = _controllerMenu;

            StartCurrentController();
        }
    }
}
