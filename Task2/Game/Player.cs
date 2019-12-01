using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player : GameObject, IWalkable, IPlayerable
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
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }

        public void Move()
        {

        }

        public void ReceiveDamage(int damage)
        {
            Health -= damage;
        }

        public Player(Vector2 position, int health) : base(position)
        {
            Health = health;
        }

        public void ReceiveHealthBonus(int i)
        {
            Health += i;
        }
    }
}
