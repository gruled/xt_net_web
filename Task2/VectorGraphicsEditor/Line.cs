using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorGraphicsEditor
{
    class Line : Figure
    {
        public Vector2 EndPosition;

        public Line(Vector2 centerPosition, Vector2 endPosition) : base(centerPosition)
        {
            this.EndPosition = endPosition;
        }

        public double Length => Math.Sqrt((CenterPosition.X - EndPosition.X) * (CenterPosition.X - EndPosition.X) +
                                          (CenterPosition.Y - EndPosition.Y) * (CenterPosition.Y - EndPosition.Y));

        public override void GetDescription()
        {
            base.GetDescription();
            Console.WriteLine("End position: " + EndPosition.ToString());
            Console.WriteLine("Length: " + Length);
        }

    }
}
