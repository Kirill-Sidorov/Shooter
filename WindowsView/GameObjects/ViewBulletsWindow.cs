using Model.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Items;

namespace WindowsView.GameObjects
{
    public class ViewBulletsWindow : ViewObject
    {
        private List<Bullet> _bullets;

        /// <summary>
        /// Объект двойной буфферизации
        /// </summary>
        private BufferedGraphics _bufferedGraphics;

        public ViewBulletsWindow(List<Bullet> parBullets, BufferedGraphics parBufferedGraphics, int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
            _bufferedGraphics = parBufferedGraphics;
            _bullets = parBullets;
        }

        public override void Draw()
        {
            foreach (Bullet bullet in _bullets)
            {
                _bufferedGraphics.Graphics.FillRectangle(Brushes.Red, bullet.X + _offsetX, bullet.Y + _offsetY, 5, 5);
            } 
        }
    }
}
