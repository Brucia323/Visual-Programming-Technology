using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    class Triangle:Graphics
    {
        public double Area(int a,int b,int c)
        {
            int p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}
