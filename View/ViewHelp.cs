using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public abstract class ViewHelp : ViewCommon
    {
        protected ModelHelp _modelHelp;

        public ViewHelp(ModelHelp parModelHelp)
        {
            _modelHelp = parModelHelp;
        }
    }
}
