using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Rock : GameObject, IObstacleable
    {
        public Rock(Vector2 position) : base(position)
        {

        }
    }
}
