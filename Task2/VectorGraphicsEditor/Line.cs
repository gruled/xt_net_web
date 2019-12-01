using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorGraphicsEditor
{
    class Line : Figure
    {

        public Vector2 EndPosition { get; set; }

        public Line(Vector2 startPosition, Vector2 endPosition) : base(startPosition)
        {
            EndPosition = endPosition;
        }

        public double Length => _calcLength();

        private double _calcLength()
        {
            return Math.Sqrt((Position.X - EndPosition.X) * (Position.X - EndPosition.X) +
                             (Position.Y - EndPosition.Y) * (Position.Y - EndPosition.Y));
        }

        public override string GetDescription()
        {
            return base.GetDescription() + " Length: " + Length;
        }
    }
}
