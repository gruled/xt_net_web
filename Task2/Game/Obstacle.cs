using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Obstacle : GameObject, IObstacle
    {
        public Obstacle(Vector2 position, string name) : base(position, name)
        {
        }

        public void Collide(DinamicGameObject obj)
        {
            obj.Move();
        }
    }
}
