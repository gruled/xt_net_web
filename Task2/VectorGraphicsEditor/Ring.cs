using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorGraphicsEditor
{
    class Ring : Circle
    {
        private double _outerRadius;
        public double OuterRadius
        {
            get => _outerRadius;
            set
            {
                if (value >= 0 && value >= base.Radius)
                {
                    _outerRadius = value;
                }
                else
                {
                    throw new ArgumentException("Внешний радиус должен иметь положительное значение и быть больше внутреннего радиуса");
                }
            }
        }

        public double InnerRadius
        {
            get => base.Radius;
            set
            {
                if (value >= 0 && value <= _outerRadius)
                {
                    base.Radius = value;
                }
                else
                {
                    throw new ArgumentException("Внутренний радиус должен иметь положительное значение и быть меньше внешнего радиуса");
                }
            }
        }

        public double Length => Math.PI * (InnerRadius * 2 + OuterRadius * 2);

        public double Area => Math.PI * (OuterRadius * OuterRadius - InnerRadius * InnerRadius);

        public Ring(Vector2 centerPosition, double innerRadius, double outerRadius) : base(centerPosition, innerRadius)
        {
            OuterRadius = outerRadius;
            InnerRadius = innerRadius;
        }

        public override void GetDescription()
        {
            base.GetDescription();
            Console.WriteLine("Outer radius: " + OuterRadius);
            Console.WriteLine("Длина: " + Length);
            Console.WriteLine("Площадь: " + Area);
        }
    }
}
