using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;

namespace WindowsView
{
    public class ViewRecordsTableWindow : ViewRecord
    {
        public event DKey KeyDownRecordsTable;

        private Form _form;

        private Font _font;

        private Graphics _graphics;

        public ViewRecordsTableWindow(ModelRecords parModelRecords) : base(parModelRecords)
        {
            _form = ViewForm.GetInstance();
            _graphics = _form.CreateGraphics();
            _font = new Font("Arial", 20);
        }

        private void ViewRecordsTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                KeyDownRecordsTable?.Invoke(e);
            }
        }

        private void ViewRecordsTable_Paint(object sender, PaintEventArgs e)
        {
            Redraw();
        }

        public override void ShowView()
        {
            _form.KeyDown += ViewRecordsTable_KeyDown;
            _form.Paint += ViewRecordsTable_Paint;
            Redraw();
        }

        public override void CloseView()
        {
            _form.KeyDown -= ViewRecordsTable_KeyDown;
            _form.Paint -= ViewRecordsTable_Paint;
        }

        private void Redraw()
        {
            int offsetY = 20;
            _graphics.Clear(Color.White);
            _graphics.DrawString("Игрок", _font, Brushes.Black, 300, offsetY);
            _graphics.DrawString("Очки", _font, Brushes.Black, 500, offsetY);
            foreach (Record record in _modelRecords.ListRecords)
            {
                offsetY += 30;
                _graphics.DrawString( record.Name, _font, Brushes.Black, 300, offsetY);
                _graphics.DrawString(String.Format("{0,5:D}", record.Score), _font, Brushes.Black, 500, offsetY);
            }
        }
    }
}
