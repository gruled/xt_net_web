using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface IPlayerable
    {
        void DecreaseHealth(int i);
        void IncreaseHealth(int i);
    }
}
