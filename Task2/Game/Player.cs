using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player : DinamicGameObject, IPlayerable
    {

        private int _health;

        public int Health
        {
            get => _health;
            set
            {
                if (value >= 0)
                {
                    _health = value;
                }
                else
                {
                    _health = 1;
                }
            }
        }

        public Player(Vector2 position, string name, int health) : base(position, name)
        {
            Health = health;
        }

        public void DecreaseHealth(int i)
        {
            Health -= i;
        }

        public void IncreaseHealth(int i)
        {
            Health += i;
        }

        public override void Move()
        {
            //реализация хотьбы игроком
        }
    }
}
