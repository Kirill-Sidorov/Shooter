using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;

namespace Controller
{
    public abstract class ControllerMenu : ControllerCommon
    {
        protected ModelMenu _modelMenu;

        protected ViewMenu _viewMenu;

        public ControllerMenu(ControllerMain parControllerMain, ModelMenu parModelMenu) : base(parControllerMain)
        {
            _modelMenu = parModelMenu;
        }
    }
}
