using Model;
using Model.GameObjects;
using System.Drawing;
using View.Items;

namespace WindowsView.GameObjects
{
    public class ViewPlayerWindow : ViewObject
    {
        private Player _player;

        private Image _imageUp = Properties.Resources.up;
        private Image _imageDown = Properties.Resources.down;
        private Image _imageRight = Properties.Resources.right;
        private Image _imageLeft = Properties.Resources.left;
        private Image _imageDead = Properties.Resources.dead;

        /// <summary>
        /// Объект двойной буфферизации
        /// </summary>
        private BufferedGraphics _bufferedGraphics;

        public ViewPlayerWindow(Player parPlayer, BufferedGraphics parBufferedGraphics, int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
            _bufferedGraphics = parBufferedGraphics;
            _player = parPlayer;
        }

        public override void Draw()
        {
            _bufferedGraphics.Graphics.DrawImage(GetPlayerImage(), _player.X + _offsetX, _player.Y + _offsetY);
        }

        public void DrawDeadPlayer()
        {
            _bufferedGraphics.Graphics.DrawImage(_imageDead, _player.X + _offsetX, _player.Y + _offsetY);
        }

        private Image GetPlayerImage()
        {
            switch (_player.Direction)
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
