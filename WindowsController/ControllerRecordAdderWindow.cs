using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsView;

namespace WindowsController
{
    public class ControllerRecordAdderWindow : ControllerRecordAdder
    {
        public ControllerRecordAdderWindow(ControllerMain parControllerMain, ModelRecords parModelRecords) : base(parControllerMain, parModelRecords)
        {
            _viewRecordAdder = new ViewRecordAdderWindow(_modelRecords);
            ((ViewRecordAdderWindow)_viewRecordAdder).KeyDownTextBox += ControllerRecordAdder_KeyDownTextBox;
        }

        public override void Start()
        {
            _viewRecordAdder.ShowView();
        }

        public override void Stop()
        {
            _viewRecordAdder.CloseView();
        }

        private void ControllerRecordAdder_KeyDownTextBox(string parString)
        {
            _modelRecords.ListRecords.Add(new Record(parString, GamePoints));
            _modelRecords.WriteToFile();
            _controller.ChangeOnControllerMenu();
        }
    }
}
