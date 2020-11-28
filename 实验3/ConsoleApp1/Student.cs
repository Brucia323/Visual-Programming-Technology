using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Student
    {
        string name;
        string sex;
        int age;
        string major;
        public Student(string name, string sex, int age, string major)
        {
            this.name = name;//姓名
            this.sex = sex;//性别
            this.age = age;//年龄
            this.major = major;//专业
        }
        public string disname()
        {
            return name;
        }
        public string dissex()
        {
            return sex;
        }
        public int disage()
        {
            return age;
        }
        public string dismajor()
        {
            return major;
        }
        ~Student() { }
    }
}
