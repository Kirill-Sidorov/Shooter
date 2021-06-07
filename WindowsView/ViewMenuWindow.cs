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
    public class ViewMenuWindow : ViewMenu
    {

        public event DKey KeyDownMenu;

        private Form _form;

        private Font _font;

        private Graphics _graphics;

        public ViewMenuWindow(ModelMenu parModelMenu) : base(parModelMenu)
        {
            _form = ViewForm.GetInstance();
            _graphics = _form.CreateGraphics();
            _font = new Font("Arial", 20);

            _modelMenu.NeedRedraw += Redraw;
        }

        private void ViewMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Enter)
                return;
            KeyDownMenu?.Invoke(e);
        }

        private void ViewMenu_Paint(object sender, PaintEventArgs e)
        {
            Redraw();
        }

        public override void ShowView()
        {
            _form.KeyDown += ViewMenu_KeyDown;
            _form.Paint += ViewMenu_Paint;
            Redraw();
            if (Application.OpenForms.Count == 0)
            {
                Application.Run(_form);
            }
        }

        public override void CloseView()
        {
            _form.KeyDown -= ViewMenu_KeyDown;
            _form.Paint -= ViewMenu_Paint;
        }

        private void Redraw()
        {
            int offsetY = 0;
            _graphics.Clear(Color.White);
            foreach (Model.MenuItem item in _modelMenu.Items.Values)
            {
                DrawMenuItem(item, offsetY);
                offsetY += 80;
            }
        }

        private void DrawMenuItem(Model.MenuItem parItem, int offsetY)
        {
            Brush brush = Brushes.Black;

            switch (parItem.CurrentStatus)
            {
                case Status.NORMAL:
                    brush = Brushes.White;
                    break;
                case Status.FOCUSED:
                    brush = Brushes.Pink;
                    break;
            }
            _graphics.FillRectangle(brush, 400, 180 + offsetY, 170, 50);
            _graphics.DrawRectangle(Pens.Black, 400, 180 + offsetY, 170, 50);

            RectangleF rect = new RectangleF(400 + 10, 180 + offsetY + 10, 170 - 10, 50 - 10);
            _graphics.DrawString(parItem.Name, _font, Brushes.Black, rect);
        }
    }
}
