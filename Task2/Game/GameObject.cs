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
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                if (value != null)
                {
                    _name = value;
                }
                else
                {
                    _name = "SomeObject";
                }
            }
        }

        public Vector2 Position
        {
            get => _position;
            set
            {
                if (value.X > 0 && value.X <= Map.Width)
                {
                    _position.X = value.X;
                }
                else
                {
                    _position.X = Map.Width;
                }

                if (value.Y > 0 && value.Y <= Map.Height)
                {
                    _position.Y = value.Y;
                }
                else
                {
                    _position.Y = Map.Height;
                }
            }
        }

        public GameObject(Vector2 position, string name)
        {
            this.Position = position;
            this.Name = name;
        }
    }
}
