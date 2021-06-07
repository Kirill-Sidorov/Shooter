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
    public class ViewHelpWindow : ViewHelp
    {
        public event DKey KeyDownHelp;

        private Form _form;

        private Font _font;

        private Graphics _graphics;

        public ViewHelpWindow(ModelHelp parModelHelp) : base(parModelHelp)
        {
            _form = ViewForm.GetInstance();
            _graphics = _form.CreateGraphics();
            _font = new Font("Arial", 20);
        }

        private void ViewHelp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                KeyDownHelp?.Invoke(e);
            }
        }

        private void ViewHelp_Paint(object sender, PaintEventArgs e)
        {
            Redraw();
        }

        public override void ShowView()
        {
            _form.KeyDown += ViewHelp_KeyDown;
            _form.Paint += ViewHelp_Paint;
            Redraw();
        }

        public override void CloseView()
        {
            _form.KeyDown -= ViewHelp_KeyDown;
            _form.Paint -= ViewHelp_Paint;
        }

        private void Redraw()
        {
            _graphics.Clear(Color.White);
            _graphics.DrawString(_modelHelp.Text, _font, Brushes.Black, 10, 10);
        }
    }
}
