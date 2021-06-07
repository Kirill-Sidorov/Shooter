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
    public delegate void DKeyDownTextBox(string parString);

    public class ViewRecordAdderWindow : ViewRecord
    {
        public event DKeyDownTextBox KeyDownTextBox;

        private Form _dialog;

        private TextBox _textBox;

        private Font _font;

        public ViewRecordAdderWindow(ModelRecords parModelRecords) : base(parModelRecords)
        {
            _dialog = new Form();
            _dialog.Size = new Size(500, 400);

            _textBox = new TextBox();
            _textBox.Size = new Size(400, 50);
            _textBox.Location = new Point(50, 200);

            _font = new Font("Arial", 20);
            _textBox.Font = _font;

            _textBox.KeyDown += ViewRecordAdder_KeyDownTextBox;
            _dialog.Paint += ViewRecordAdder_Paint;
            _dialog.Controls.Add(_textBox);
            _dialog.ActiveControl = _textBox;
            _dialog.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ViewRecordAdder_KeyDownTextBox (object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                KeyDownTextBox?.Invoke(_textBox.Text);
            }
        }
        
        private void ViewRecordAdder_Paint (object sender, PaintEventArgs e)
        {
            Graphics graphics = _dialog.CreateGraphics();
            graphics.DrawString("Введите имя и нажмите Enter: ", _font, Brushes.Black, 60, 50);
        }
        
        public override void ShowView()
        {
            _textBox.Clear();
            _dialog.ShowDialog();
        }

        public override void CloseView()
        {
            _dialog.Close();
        }
    }
}
