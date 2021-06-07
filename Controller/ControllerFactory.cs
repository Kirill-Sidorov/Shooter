using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public abstract class ControllerFactory
    {
        protected ModelRecords _modelRecords;

        protected ControllerMain _controller;

        public ControllerFactory(ControllerMain parControllerMain)
        {
            _controller = parControllerMain;
        }

        public abstract ControllerCommon CreateControllerGame();
        public abstract ControllerCommon CreateControllerMenu();
        public abstract ControllerCommon CreateControllerHelp();
        public abstract ControllerCommon CreateControllerRecordAdder();
        public abstract ControllerCommon CreateControllerRecordsTable();
    }
}
