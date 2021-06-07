using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.GameObjects
{
    public abstract class GameObject
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Speed { get; set; }

        public Direction Direction { get; set; }
    }
}
