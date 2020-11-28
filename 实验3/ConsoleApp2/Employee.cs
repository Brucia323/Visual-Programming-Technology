using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class Employee
    {
        long workNum;//工号
        string name;//姓名
        int basicSalary;//基本工资
        int rewards;//奖金
        static int employeeNum = 0;//总员工人数
        public long WorkNum;//工号
        public string Name;//姓名
        public int BasicSalary;//基本工资
        public int Rewards;//奖金
        private int salary;//应发工资
        public int Salary { get => salary; }//只读
        public Employee() { }
        public Employee(long WorkNum, string Name, int BasicSalary, int Rewards)//构造函数
        {
            this.workNum = WorkNum;
            this.name = Name;
            this.basicSalary = BasicSalary;
            this.rewards = Rewards;
            employeeNum++;//员工人数加1
        }
        public int CalTotalSalary(int basicSalary, int rewards)//计算应发工资
        {
            salary = basicSalary + rewards;
            return salary;
        }
        public string DisplayEmployeeInfo(long WorkNum, string Name, int BasicSalary, int Rewards)//显示员工当前信息
        {
            return WorkNum + " " + Name + " " + BasicSalary + " " + Rewards;
        }
        public int DisplayEmployeeNumber()//显示总员工人数
        {
            return employeeNum;
        }
        ~Employee()//析构函数
        {
            employeeNum--;//员工人数减1
            Console.WriteLine(employeeNum);//显示当前人数信息
        }
    }
}
