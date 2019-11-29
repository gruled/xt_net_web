using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Map
    {
        public List<DinamicGameObject> DinamicList;
        public List<Bonus> BonusList;
        public List<Obstacle> ObstacleList;

        private static double _width;

        public static double Width
        {
            get => _width;
            set
            {
                if (value > 0.0)
                {
                    _width = value;
                }
                else
                {
                    _width = 1.0;
                }
            }
        }

        private static double _height;

        public static double Height
        {
            get => _height;
            set
            {
                if (value > 0.0)
                {
                    _height = value;
                }
                else
                {
                    _height = 1.0;
                }
            }
        }

        public Map(double width, double height)
        {
            Map.Width = width;
            Map.Height = height;
        }
    }
}
