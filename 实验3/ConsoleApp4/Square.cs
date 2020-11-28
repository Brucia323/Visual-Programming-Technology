using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    class Square:Rectangular
    {
        public double Area(int a)
        {
            return Math.Pow(a, 2);
        }
    }
}
