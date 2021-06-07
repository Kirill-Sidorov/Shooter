using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;

namespace Controller
{
    public abstract class ControllerRecordAdder : ControllerCommon
    {
        protected ModelRecords _modelRecords;

        protected ViewRecord _viewRecordAdder;

        public int GamePoints { protected get; set; }

        public ControllerRecordAdder(ControllerMain parControllerMain, ModelRecords parModelRecords) : base(parControllerMain)
        {
            _modelRecords = parModelRecords;
        }
    }
}
