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
    public class ControllerMenuWindow : ControllerMenu
    {
        public ControllerMenuWindow(ControllerMain parControllerMain, ModelMenu parModelMenu) : base(parControllerMain, parModelMenu)
        {
            _modelMenu.Items[(int)ItemCode.GAME].Selected += _controller.ChangeOnControllerGame;
            _modelMenu.Items[(int)ItemCode.RECORDS].Selected += _controller.ChangeOnControllerRecordsTable;
            _modelMenu.Items[(int)ItemCode.HELP].Selected += _controller.ChangeOnControllerHelp;
            _modelMenu.Items[(int)ItemCode.EXIT].Selected += () => Application.Exit();

            _viewMenu = new ViewMenuWindow(_modelMenu);
            ((ViewMenuWindow)_viewMenu).KeyDownMenu += ControllerMenuWindow_KeyDown;
        }

        public override void Start()
        {
            _viewMenu.ShowView();
        }

        public override void Stop()
        {
            _viewMenu.CloseView();
        }

        private void ControllerMenuWindow_KeyDown(KeyEventArgs parE)
        {
            switch (parE.KeyData)
            {
                case Keys.Down:
                    _modelMenu.FocusNext();
                    break;
                case Keys.Up:
                    _modelMenu.FocusPrevious();
                    break;
                case Keys.Enter:
                    _modelMenu.SelectFocusedItem();
                    break;
            }
        }
    }
}
