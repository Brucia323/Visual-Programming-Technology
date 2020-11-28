using System;

namespace ConsoleApp2
{
    class Program
    {
        struct student
        {
            public long no;
            public string name;
            public int math;
            public int english;
        }
        static void Main(string[] args)
        {
            student[] stu = new student[10];
            student temp;
            int i = 0, j;
            Console.WriteLine("请输入10个学生的学号、姓名、高数、英语课程的成绩");
            try
            {
                for (i = 0; i < 10; i++)
                {
                    string b;
                    b = Console.ReadLine();
                    string[] c = b.Split(' ');
                    stu[i].no = long.Parse(c[0]);
                    stu[i].name = c[1];
                    stu[i].math = int.Parse(c[2]);
                    stu[i].english = int.Parse(c[3]);
                }
            }
            catch
            {
                stu[i].name = Console.ReadLine();
                stu[i].math = int.Parse(Console.ReadLine());
                stu[i].english = int.Parse(Console.ReadLine());
                for (i = 1; i < 10; i++)
                {
                    stu[i].no = long.Parse(Console.ReadLine());
                    stu[i].name = Console.ReadLine();
                    stu[i].math = int.Parse(Console.ReadLine());
                    stu[i].english = int.Parse(Console.ReadLine());
                }

            }
            for (j = 9; j > 0; j--)
                for (i = 0; i < j; i++)
                    if (stu[i].math + stu[i].english < stu[i + 1].math + stu[i + 1].english)
                    {
                        temp = stu[i + 1];
                        stu[i + 1] = stu[i];
                        stu[i] = temp;
                    }
            for (i = 0; i < 10; i++)
                Console.WriteLine("{0} {1} {2} {3}", stu[i].no, stu[i].name, stu[i].math, stu[i].english);
            //Console.WriteLine("{0} {1}", stu[i].no, stu[i].name);
        }
    }
}
