using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    abstract class GameObject
    {

        private Vector2 _position;

        public Vector2 Position
        {
            get => _position;
            set
            {
                if ((value.X >= 0 && value.Y >= 0) && (value.X <= Map.Width && value.Y <= Map.Height))
                {
                    _position.X = value.X;
                    _position.Y = value.Y;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        protected GameObject(Vector2 position)
        {
            Position = position;
        }
    }
}
