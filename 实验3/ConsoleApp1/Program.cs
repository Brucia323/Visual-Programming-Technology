using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student stu1 = new Student("张晓虹", "女", 20, "计算机科学与技术");
            Student stu2 = new Student("王宏", "男", 18, "软件工程");
            Console.WriteLine("大家好，我叫{0}", stu1.disname());
            Console.WriteLine("我的性别是{0}", stu1.dissex());
            Console.WriteLine("我今年{0}岁了", stu1.disage());
            Console.WriteLine("我学的专业是{0}", stu1.dismajor());
            Console.WriteLine("大家好，我叫{0}", stu2.disname());
            Console.WriteLine("我的性别是{0}", stu2.dissex());
            Console.WriteLine("我今年{0}岁了", stu2.disage());
            Console.WriteLine("我学的专业是{0}", stu2.dismajor());
        }
    }
}
