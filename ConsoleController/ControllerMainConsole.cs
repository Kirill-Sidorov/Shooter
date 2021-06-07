using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleController
{
    public class ControllerMainConsole : ControllerMain
    {
        public ControllerMainConsole()
        {
            ControllerFactoryConsole factory = new ControllerFactoryConsole(this);
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
