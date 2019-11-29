using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorGraphicsEditor
{
    abstract class Figure
    {
        public Vector2 CenterPosition;

        public Figure(Vector2 centerPosition)
        {
            this.CenterPosition = centerPosition;
        }

        public virtual void GetDescription()
        {
            Console.WriteLine("Center position: " + CenterPosition.ToString());
        }

    }
}
