using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Ring
    {
        public double X;
        public double Y;

        private double _innerRadius;
        private double _outerRadius;

        public double InnerRadius
        {
            get => _innerRadius;
            set
            {
                if (value >= 0 && value <= _outerRadius)
                {
                    _innerRadius = value;
                }
                else
                {
                    _innerRadius = 0.0;
                }
            }
        }

        public double OuterRadius
        {
            get => _outerRadius;
            set
            {
                if (value >= 0 && value >= _innerRadius)
                {
                    _outerRadius = value;
                }
                else
                {
                    _outerRadius = _innerRadius;
                }
            }
        }

        public Ring(double x, double y, double innerRadius, double outerRadius)
        {
            this.X = x;
            this.Y = y;
            this.OuterRadius = outerRadius;
            this.InnerRadius = innerRadius;
        }

        public double Area => Math.PI * (_outerRadius * _outerRadius - _innerRadius * _innerRadius);

        public double Length => Math.PI * (_outerRadius * 2 + _innerRadius * 2);

    }
}
