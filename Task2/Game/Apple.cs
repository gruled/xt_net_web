using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Apple : GameObject, IBonusable
    {
        private int _healthBonus;

        public int HealthBonus
        {
            get => _healthBonus;
            set
            {
                if (value >= 0)
                {
                    _healthBonus = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }

        public Apple(Vector2 position, int bonus) : base(position)
        {
            HealthBonus = bonus;
        }

        public void DoBonus(IPlayerable player)
        {
            player.ReceiveHealthBonus(HealthBonus);
        }
    }
}
