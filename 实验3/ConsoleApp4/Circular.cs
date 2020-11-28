using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    class Circular:Graphics
    {
        public double Area(int r)
        {
            return Math.PI * Math.Pow(r, 2);
        }
    }
}
