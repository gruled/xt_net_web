using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface IPlayerable
    {
        void ReceiveDamage(int i);
        void ReceiveHealthBonus(int i);
    }
}
