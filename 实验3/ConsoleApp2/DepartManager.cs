using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsoleApp2
{
    class DepartManager : Employee
    {
        string nameDepart;//部门名称
        int performanceSalary;//经理绩效工资
        private string nameDepart1;//部门名称
        public int PerformanceSalary;//经理绩效工资

        public string NameDepart { get => nameDepart1; }//只读

        public DepartManager() { }
        public DepartManager(string NameDepart, int PerformanceSalary)
        {
            this.nameDepart = NameDepart;
            this.performanceSalary = PerformanceSalary;
        }
        public int CalTotalSalary(int basicSalary, int rewards, int PerformanceSalary)//计算经理应发工资
        {
            Salary = basicSalary + rewards + performanceSalary;
            return Salary;
        }
        public string DisplayEmployeeInfo(string NameDepart, long WorkNum, string Name, int BasicSalary, int Rewards)//显示经理当前信息
        {
            return NameDepart + " " + WorkNum + " " + Name + " " + BasicSalary + " " + Rewards;
        }
        ~DepartManager()
        {
            Console.WriteLine(nameDepart);
        }
    }
}
