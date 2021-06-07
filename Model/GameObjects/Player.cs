using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.GameObjects
{
    public class Player : GameObject
    {
        public int Health { get; set; }

        public Player()
        {
            X = 200;
            Y = 200;
            Speed = 10;
            Health = 100;
        }
    }
}
