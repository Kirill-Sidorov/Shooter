using Model.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Items;

namespace ConsoleView.GameObjects
{
    public class ViewZombiesConsole : ViewObject
    {
        private Zombie[] _zombies;
        private ConsoleColor _color;

        public ViewZombiesConsole(ref Zombie[] parZombies,int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
            _zombies = parZombies;
            _color = ConsoleColor.Green;
        }

        public override void Draw()
        {
            foreach (Zombie zombie in _zombies)
            {
                int x = _offsetX + zombie.X / 10;
                int y = _offsetY + zombie.Y / 10;
                ConsoleOutput.Write("███", x, y, _color);
            }
        }
    }
}
