using Model;
using Model.GameObjects;
using System.Drawing;
using View.Items;

namespace WindowsView.GameObjects
{
    public class ViewZombiesWindow : ViewObject
    {
        private Zombie[] _zombies;

        private Image _imageUp = Properties.Resources.zup;
        private Image _imageDown = Properties.Resources.zdown;
        private Image _imageRight = Properties.Resources.zright;
        private Image _imageLeft = Properties.Resources.zleft;

        /// <summary>
        /// Объект двойной буфферизации
        /// </summary>
        private BufferedGraphics _bufferedGraphics;

        public ViewZombiesWindow(ref Zombie[] parZombies, BufferedGraphics parBufferedGraphics, int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
            _bufferedGraphics = parBufferedGraphics;
            _zombies = parZombies;
        }

        public override void Draw()
        {
            foreach(Zombie zombie in _zombies)
            {
                _bufferedGraphics.Graphics.DrawImage(GetZombieImage(zombie), zombie.X + _offsetX, zombie.Y + _offsetY);
            }
        }

        private Image GetZombieImage(Zombie parZombie)
        {
            switch (parZombie.Direction)
            {
                case Direction.LEFT:
                    return _imageLeft;
                case Direction.RIGHT:
                    return _imageRight;
                case Direction.UP:
                    return _imageUp;
                case Direction.DOWN:
                    return _imageDown;
                default:
                    return _imageUp;
            }
        }
    }
}
