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
    public class ViewAmmoWindow : ViewObject
    {
        private Ammo _ammo;

        private Image _imageAmmo = Properties.Resources.ammo_Image;

        /// <summary>
        /// Объект двойной буфферизации
        /// </summary>
        private BufferedGraphics _bufferedGraphics;

        public ViewAmmoWindow(Ammo parAmmo, BufferedGraphics parBufferedGraphics, int parOffsetX, int parOffsetY) : base (parOffsetX, parOffsetY)
        {
            _bufferedGraphics = parBufferedGraphics;
            _ammo = parAmmo;
        }

        public override void Draw()
        {
            if (_ammo.IsExist)
            {
                _bufferedGraphics.Graphics.DrawImage(_imageAmmo, _ammo.X + _offsetX, _ammo.Y + _offsetY);
            }
        }
    }
}
