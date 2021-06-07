using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public abstract class ViewRecord : ViewCommon
    {
        protected ModelRecords _modelRecords;

        public ViewRecord(ModelRecords parModelRecords)
        {
            _modelRecords = parModelRecords;
        }
    }
}
