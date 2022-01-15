using System;

namespace experment2
{
    class Program
    {
        struct student{
            public long no;
            public string name;
            public DateTime DateTime;
        };
        static void Main(string[] args)
        {
            student s1, s2;
            s1.no = 1;
            s1.name = "";
            s1.DateTime = new DateTime(1998, 4, 11);
            s2.no = 2;
            s2.name = "";
            s2.DateTime = new DateTime(1997, 1, 25);
            Console.WriteLine("{0}的生日为{1}", s1.name, s1.DateTime);
            Console.WriteLine("{0}的生日为{1}", s2.name, s2.DateTime);
            Console.WriteLine("{0}出生在{1}", s1.name, s1.DateTime.ToString("dddd",new System.Globalization.CultureInfo("zh-cn")));
            Console.WriteLine("{0}出生在{1}", s2.name, s2.DateTime.ToString("dddd",new System.Globalization.CultureInfo("zh-cn")));
            Console.WriteLine("{0}和{1}相差{2}天", s2.name, s1.name, s1.DateTime-s2.DateTime);
            Console.ReadKey();
        }
    }
}
