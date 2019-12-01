using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Map
    {
        public List<IWalkable> LisWalkables = new List<IWalkable>();

        public List<IBonusable> ListBonusables = new List<IBonusable>();

        public List<IObstacleable> ListObstacleables = new List<IObstacleable>();

        private static double _width;

        public static double Width
        {
            get => _width;
            set
            {
                if (value > 0)
                {
                    _width = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }

        private static double _height;

        public static double Height
        {
            get => _height;
            set
            {
                if (value > 0)
                {
                    _height = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }
    }
}
