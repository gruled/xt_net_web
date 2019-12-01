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

        public double Width
        {
            get => _width;
            set
            {
                if (value > 0)
                {
                    _width = value;
                    _area = _calcArea();
                    _perimeter = _calcPerimeter();
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Width must be greater then 0");
                }
            }
        }

        private double _height;

        public double Height
        {
            get => _height;
            set
            {
                if (value > 0)
                {
                    _height = value;
                    _area = _calcArea();
                    _perimeter = _calcPerimeter();
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Height must be greater then 0");
                }
            }
        }

        private double _area;

        public double Area => _area;

        private double _calcArea()
        {
            return Width * Height;
        }

        private double _perimeter;
        public double Perimeter => _perimeter;

        private double _calcPerimeter()
        {
            return Width + Width + Height + Height;
        }

        public Rectangle(Vector2 position, double width, double height) : base(position)
        {
            Width = width;
            Height = height;
            _area = _calcArea();
            _perimeter = _calcPerimeter();
        }

        public override string GetDescription()
        {
            return base.GetDescription() + " Width: " + Width + " Height: " + Height + " Area: " + Area + " Perimeter: " + Perimeter;
        }
    }
}
