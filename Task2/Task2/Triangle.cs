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
                if (value > 0)
                {
                    _a = value;
                }
                else
                {
                    _a = 1;
                }

            }
        }

        public double B
        {
            get => _b;
            set
            {
                if (value > 0)
                {
                    _b = value;
                }
                else
                {
                    _b = 1;
                }

            }
        }

        public double C
        {
            get => _c;
            set
            {
                if (value > 0)
                {
                    _c = value;
                }
                else
                {
                    _c = 1;
                }

            }
        }

        public Triangle(double a, double b, double c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }

        public double Perimeter => A + B + C;

        public double Area =>
            Math.Sqrt((Perimeter / 2) * ((Perimeter / 2) - A) * ((Perimeter / 2) - B) * ((Perimeter / 2) - C));
    }
}
