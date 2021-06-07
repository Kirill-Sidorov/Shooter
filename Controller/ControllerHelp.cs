using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;

namespace Controller
{
    public abstract class ControllerHelp : ControllerCommon
    {
        protected ModelHelp _modelHelp;

        protected ViewHelp _viewHelp;

        public ControllerHelp(ControllerMain parControllerMain, ModelHelp parModelHelp) : base (parControllerMain)
        {
            _modelHelp = parModelHelp;
        }
    }
}
