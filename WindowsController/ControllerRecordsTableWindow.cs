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
    public class ControllerRecordsTableWindow : ControllerRecordsTable
    {
        public ControllerRecordsTableWindow(ControllerMain parControllerMain, ModelRecords parModelRecords) : base(parControllerMain, parModelRecords)
        {
            _viewRecordsTable = new ViewRecordsTableWindow(_modelRecords);
            ((ViewRecordsTableWindow)_viewRecordsTable).KeyDownRecordsTable += ControllerRecordsTableWindow_KeyDown;
        }

        public override void Start()
        {
            _viewRecordsTable.ShowView();
        }

        public override void Stop()
        {
            _viewRecordsTable.CloseView();
        }

        private void ControllerRecordsTableWindow_KeyDown(KeyEventArgs parE)
        {
            if (parE.KeyData == Keys.Escape)
            {
                _controller.ChangeOnControllerMenu();
            }
        }
    }
}
