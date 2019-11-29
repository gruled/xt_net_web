using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    abstract class DinamicGameObject : GameObject
    {
        public DinamicGameObject(Vector2 position, string name) : base(position, name)
        {

        }

        public virtual void Move()
        {

        }
    }
}
