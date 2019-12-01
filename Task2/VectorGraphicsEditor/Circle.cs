using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorGraphicsEditor
{
    class Circle : Figure
    {
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
                    throw new ArgumentOutOfRangeException(nameof(value), "Radius must be greater then 0");
                }
            }
        }

        public Circle(Vector2 position, double radius) : base(position)
        {
            Radius = radius;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + " Radius: " + Radius;
        }
    }
}
