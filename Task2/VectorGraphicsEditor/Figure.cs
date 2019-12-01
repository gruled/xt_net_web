using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorGraphicsEditor
{
    abstract class Figure : IDescriptionable
    {
        public Vector2 Position { get; set; }

        protected Figure(Vector2 position)
        {
            Position = position;
        }

        public virtual String GetDescription()
        {
            return "Type: " + GetType().Name + " Position: " + Position.X + ", " + Position.Y;
        }
    }
}
