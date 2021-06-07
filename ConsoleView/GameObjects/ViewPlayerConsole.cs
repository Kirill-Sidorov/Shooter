using Model.GameObjects;
using System;
using View.Items;

namespace ConsoleView.GameObjects
{
    public class ViewPlayerConsole : ViewObject
    {
        private Player _player;
        private ConsoleColor _color;

        public ViewPlayerConsole(Player parPlayer, int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
            _player = parPlayer;
            _color = ConsoleColor.White;
        }

        public override void Draw()
        {
            int x = _offsetX + _player.X / 10;
            int y = _offsetY + _player.Y / 10;
            ConsoleOutput.Write("███", x, y, _color);
        }
    }
}
