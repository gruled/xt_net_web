using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Bonus : GameObject, IBuf
    {
        private int _healthBonus;

        public int HealthBonus
        {
            get => _healthBonus;
            set
            {
                if (value > 0)
                {
                    _healthBonus = value;
                }
                else
                {
                    _healthBonus = 1;
                }
            }
        }

        public Bonus(Vector2 position, string name, int healthBonus) : base(position, name)
        {
            HealthBonus = healthBonus;
        }

        public void DoBaf(IPlayerable player)
        {
            player.IncreaseHealth(HealthBonus);
        }
    }
}
