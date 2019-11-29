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
                if (value >= 0)
                {
                    _radius = value;
                }
                else
                {
                    throw new ArgumentException("Радиус должен иметь положительное значение");
                }
            }
        }

        public Circle(Vector2 centerPosition, double radius) : base(centerPosition)
        {
            Radius = radius;
        }

        public override void GetDescription()
        {
            base.GetDescription();
            Console.WriteLine("Radius: " + Radius);
        }

    }
}
