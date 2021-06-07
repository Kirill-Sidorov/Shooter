using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;

namespace Controller
{
    public abstract class ControllerRecordsTable : ControllerCommon
    {
        protected ModelRecords _modelRecords;

        protected ViewRecord _viewRecordsTable;

        public ControllerRecordsTable(ControllerMain parControllerMain, ModelRecords parModelRecords) : base(parControllerMain)
        {
            _modelRecords = parModelRecords;
        }
    }
}
