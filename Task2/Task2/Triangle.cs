using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Triangle
    {
        private double _a;
        private double _b;
        private double _c;

        public double A
        {
            get => _a;
            set
            {
                if (value > 0 && (value < (B + C)))
                {
                    _a = value;
                }
                else
                {
                    _a = (B+C)/2.0;
                }

            }
        }

        public double B
        {
            get => _b;
            set
            {
                if (value > 0 && (value < (A + C)))
                {
                    _b = value;
                }
                else
                {
                    _b = (A + C) / 2.0;
                }

            }
        }

        public double C
        {
            get => _c;
            set
            {
                if (value > 0 && (value < (A + B)))
                {
                    _c = value;
                }
                else
                {
                    _c = (A + B) / 2.0;
                }

            }
        }

        public Triangle(double a, double b, double c)
        {
            if (_isRightTriangle(a,b,c))
            {
                this._a = a;
                this._b = b;
                this._c = c;
            }
            else
            {
                throw new ArgumentException("Сторона должна быть меньше двух других сторон");
            }


        }

        private bool _isRightTriangle(double a, double b, double c)
        {
            if ((a < (b + c)) && (b < (a + c)) && (c < (a + b)) && a > 0 && b > 0 && c > 0)
            {
                return true;
            }

            return false;
        }

        public double Perimeter => A + B + C;

        public double Area =>
            Math.Sqrt((Perimeter / 2) * ((Perimeter / 2) - A) * ((Perimeter / 2) - B) * ((Perimeter / 2) - C));
    }
}