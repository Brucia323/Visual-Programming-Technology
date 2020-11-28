using System;

namespace ConsoleApp3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一组整数，以0结束：\n");
            int[] a = new int[100];
            int i = 0, sumo = 0, sumj = 0;
            try
            {
                string b;
                b = Console.ReadLine();
                string[] c = b.Split(' ');
                do
                {
                    a[i] = int.Parse(c[i]);
                } while (a[i++] != 0);
            }
            catch
            {
                do
                {
                    a[i] = int.Parse(Console.ReadLine());
                } while (a[i++] != 0);
            }
            for (i = 0; a[i] != 0; i++)
            {
                if (a[i] % 2 == 0)
                    sumo += a[i];
                else
                    sumj += a[i];
            }
            Console.WriteLine("奇数和是{0},偶数和是{1}", sumj, sumo);

        }
    }
}
