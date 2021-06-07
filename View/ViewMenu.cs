using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public abstract class ViewMenu : ViewCommon
    {
        protected ModelMenu _modelMenu;

        public ViewMenu(ModelMenu parModelMenu)
        {
            _modelMenu = parModelMenu;
        }
    }
}
