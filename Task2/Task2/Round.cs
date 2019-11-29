using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Round
    {
        public double X;
        public double Y;
        private double _radius;

        public double Radius
        {
            get => _radius;
            set
            {
                if (value > 0)
                {
                    _radius = value;
                }
                else
                {
                    _radius = 1;
                }
            }
        }

        public Round(double x, double y, double radius)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
        }


        public double Length => Math.PI * Radius * 2;

        public double Area => Math.PI * Radius * Radius;

    }
}
