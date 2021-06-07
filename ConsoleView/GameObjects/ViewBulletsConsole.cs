using Model.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Items;

namespace ConsoleView.GameObjects
{
    public class ViewBulletsConsole : ViewObject
    {
        private List<Bullet> _bullets;
        private ConsoleColor _color;

        public ViewBulletsConsole(List<Bullet> parBullets, int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
            _bullets = parBullets;
            _color = ConsoleColor.Red;
        }

        public override void Draw()
        {
            foreach (Bullet bullet in _bullets)
            {
                int x = _offsetX + bullet.X / 10;
                int y = _offsetY + bullet.Y / 10;
                ConsoleOutput.Write("+", x, y, _color);
            }
        }
    }
}
