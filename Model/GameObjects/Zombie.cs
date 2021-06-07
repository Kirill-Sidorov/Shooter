using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.GameObjects
{
    public class Zombie : GameObject
    {
        public Zombie(int parX, int parY)
        {
            X = parX;
            Y = parY;
            Speed = 1;
            Direction = Direction.UP;
        }
    }
}
