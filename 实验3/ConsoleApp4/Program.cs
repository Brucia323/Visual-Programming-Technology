using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangular rectangular = new Rectangular();
            Console.WriteLine(rectangular.Area(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
            Circular circular = new Circular();
            Console.WriteLine(circular.Area(int.Parse(Console.ReadLine())));
            Triangle triangle = new Triangle();
            Console.WriteLine(triangle.Area(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
            Square square = new Square();
            Console.WriteLine(square.Area(int.Parse(Console.ReadLine())));
        }
    }
}
