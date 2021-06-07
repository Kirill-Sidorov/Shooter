using Model.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Items;

namespace ConsoleView.GameObjects
{
    public class ViewAmmoConsole : ViewObject
    {
        private Ammo _ammo;
        private ConsoleColor _color;

        public ViewAmmoConsole(Ammo parAmmo, int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
            _ammo = parAmmo;
            _color = ConsoleColor.Red;
        }

        public override void Draw()
        {
            if (_ammo.IsExist)
            {
                int x = _offsetX + _ammo.X / 10;
                int y = _offsetY + _ammo.Y / 10;
                ConsoleOutput.Write("A", x, y, _color);
            }
        }
    }
}
