using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorGraphicsEditor
{
    class Rectangle : Figure
    {
        private double _width;
        private double _height;

        public double Width
        {
            get => _width;
            set
            {
                if (value >= 0.0)
                {
                    _width = value;
                }
                else
                {
                    throw new ArgumentException("Ширина должна иметь положительное значение");
                }
            }
        }

        public double Height
        {
            get => _height;
            set
            {
                if (value >= 0.0)
                {
                    _height = value;
                }
                else
                {
                    throw new ArgumentException("Высота должна иметь положительное значение");
                }
            }
        }

        public Rectangle(Vector2 centerPosition, double width, double height) : base(centerPosition)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Area => _width * _height;

        public double Length => Width * 2 + Height * 2;

        public override void GetDescription()
        {
            base.GetDescription();
            Console.WriteLine("Width: " + Width);
            Console.WriteLine("Height: " + Height);
            Console.WriteLine("Площадь: " + Area);
            Console.WriteLine("Периметр: " + Length);
        }

    }
}
