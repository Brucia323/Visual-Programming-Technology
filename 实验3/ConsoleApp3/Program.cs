using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculate calculate = new Calculate();
            Console.WriteLine(calculate.GetSum(15, 15));
            Console.WriteLine(calculate.GetSum(15, 15, 15, 15));
            Console.WriteLine(calculate.GetSum(48.8, 48.8));
            Console.WriteLine(calculate.GetSum("爱", "情", "传", "说"));
        }
    }
}
