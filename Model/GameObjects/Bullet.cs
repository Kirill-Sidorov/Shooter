using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.GameObjects
{
    public class Bullet : GameObject
    {
        public Bullet(int parX, int parY, Direction parDirection)
        {
            X = parX;
            Y = parY;
            Direction = parDirection;
            Speed = 7;
        }
    }
}
