using System;

namespace ConsoleApp3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入n");
            int n, a = 1;
            n = int.Parse(Console.ReadLine());
            int[] b = new int[n + 1], c = new int[n + 1];
            for (int j = 0; j < n + 1; j++)
            {
                b[j] = 0;
                c[j] = 0;
            }
            b[0] = a;
            for (int i = 0; i < n; i++)
            {
                for (int j = n - i; j > 0; j--)
                {
                    Console.Write("  ");
                }
                for (int j = 0; j <= i; j++)
                {
                    if (j > 0)
                        a = b[j - 1] + b[j];
                    Console.Write("{0,-4}", a);
                    c[j] = a;
                }
                Console.WriteLine();
                for (int j = 0; j < n; j++)
                {
                    b[j] = c[j];
                }
            }
        }
    }
}
