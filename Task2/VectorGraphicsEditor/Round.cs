using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorGraphicsEditor
{
    class Round : Circle
    {
        public double Length => Math.PI * Radius * 2;

        public double Area => Math.PI * Radius * Radius;

        public Round(Vector2 centerPosition, double radius) : base(centerPosition, radius)
        {
        }

        public override void GetDescription()
        {
            base.GetDescription();
            Console.WriteLine("Length: " + Length);
            Console.WriteLine("Area: " + Area);
        }
    }
}
