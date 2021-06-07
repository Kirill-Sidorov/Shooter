using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public abstract class ControllerMain
    {
        protected ControllerCommon _controllerGame;
        protected ControllerCommon _controllerMenu;
        protected ControllerCommon _controllerHelp;
        protected ControllerCommon _controllerRecordAdder;
        protected ControllerCommon _controllerRecordsTable;

        protected ControllerCommon _currentController;

        public void ChangeOnControllerGame()
        {
            _currentController.Stop();
            _currentController = _controllerGame;
            _currentController.Start();
        }

        public void ChangeOnControllerMenu()
        {
            _currentController.Stop();
            _currentController = _controllerMenu;
            _currentController.Start();
        }

        public void ChangeOnControllerHelp()
        {
            _currentController.Stop();
            _currentController = _controllerHelp;
            _currentController.Start();
        }

        public void ChangeOnControllerRecordAdder(int parGamePoints)
        {
            _currentController.Stop();
            ((ControllerRecordAdder)_controllerRecordAdder).GamePoints = parGamePoints;
            _currentController = _controllerRecordAdder;
            _currentController.Start();
        }

        public void ChangeOnControllerRecordsTable()
        {
            _currentController.Stop();
            _currentController = _controllerRecordsTable;
            _currentController.Start();
        }

        protected void StartCurrentController()
        {
            _currentController.Start();
        }

        protected void StopCurrentController()
        {
            _currentController.Stop();
        }
    }
}
