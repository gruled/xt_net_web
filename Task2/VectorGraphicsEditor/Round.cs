using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorGraphicsEditor
{
    class Round : Circle
    {
        public double Area => Math.PI * Radius * Radius;

        public double Length => Math.PI * 2 * Radius;

        public Round(Vector2 position, double radius) : base(position, radius)
        {
        }

        public override string GetDescription()
        {
            return base.GetDescription() + " Area: " + Area + " Length: " + Length;
        }
    }
}
