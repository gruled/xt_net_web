using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorGraphicsEditor
{
    class Ring : Round
    {
        private double _outerRadius;

        public double OuterRadius
        {
            get => _outerRadius;
            set
            {
                if (value > 0 && value > Radius)
                {
                    _outerRadius = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "Outer radius must be greater then 0 and greater then radius");
                }
            }
        }

        public Ring(Vector2 position, double innerRadius, double outerRadius) : base(position, innerRadius)
        {
            OuterRadius = outerRadius;
        }

        public new double Area => Math.PI * (OuterRadius * OuterRadius - Radius * Radius);

        public new double Length => Math.PI * (OuterRadius * 2 + Radius * 2);

        public override string GetDescription()
        {
            return base.GetDescription() + " Outer radius: " + OuterRadius;
        }
    }
}
