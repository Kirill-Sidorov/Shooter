using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsView;

namespace WindowsController
{
    public class ControllerHelpWindow : ControllerHelp
    {
        public ControllerHelpWindow(ControllerMain parControllerMain, ModelHelp parModelHelp) : base(parControllerMain, parModelHelp)
        {
            _viewHelp = new ViewHelpWindow(_modelHelp);
            ((ViewHelpWindow)_viewHelp).KeyDownHelp += ControllerHelpWindow_KeyDown;
        }

        public override void Start()
        {
            _viewHelp.ShowView();
        }

        public override void Stop()
        {
            _viewHelp.CloseView();
        }

        private void ControllerHelpWindow_KeyDown(KeyEventArgs parE)
        {
            if (parE.KeyData == Keys.Escape)
            {
                _controller.ChangeOnControllerMenu();
            }
        }
    }
}
