using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Enemy : DinamicGameObject, IDoDamage
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
                    _damage = 1;
                }
            }
        }

        public Enemy(Vector2 position, string name, int damage) : base(position, name)
        {
            Damage = damage;
        }

        public override void Move()
        {
            //реализация передвижения врага
        }

        public void DoDamage(IPlayerable player)
        {
            player.DecreaseHealth(Damage);
        }
    }
}
