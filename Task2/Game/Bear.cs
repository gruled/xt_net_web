using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Bear : GameObject, IWalkable, IDamageable
    {
        private int _damage;

        public int Damage
        {
            get => _damage;
            set
            {
                if (value > 0)
                {
                    _damage = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }

        public Bear(Vector2 position, int damage) : base(position)
        {
            Damage = damage;
        }

        public void Move()
        {

        }

        public void DoDamage(IPlayerable player)
        {
            player.ReceiveDamage(Damage);
        }
    }
}
