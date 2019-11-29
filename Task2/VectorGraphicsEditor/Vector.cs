using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorGraphicsEditor
{
    struct Vector2
    {
        public double X;
        public double Y;

        public Vector2(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return "X: " + X + " Y: " + Y;
        }
    }
}