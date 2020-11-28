using System;
using System.Collections;
using System.Security.Cryptography;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int salary;
            Employee employee = new Employee();
            DepartManager dm = new DepartManager();
            ArrayList list = new ArrayList();
            Console.WriteLine("请输入相关信息(工号 姓名 基本工资 奖金)");
            employee.WorkNum = long.Parse(Console.ReadLine());//工号
            employee.Name = Console.ReadLine();//姓名
            employee.BasicSalary = int.Parse(Console.ReadLine());//基本工资
            employee.Rewards = int.Parse(Console.ReadLine());//奖金
            //dm.PerformanceSalary = int.Parse(Console.ReadLine());//经理绩效工资
            list.Add(employee.WorkNum);
            list.Add(employee.Name);
            list.Add(employee.BasicSalary);
            list.Add(employee.Rewards);
            new Employee(employee.WorkNum, employee.Name, employee.BasicSalary, employee.Rewards);
            salary=employee.CalTotalSalary(employee.BasicSalary, employee.Rewards);//计算应发工资
            //salary=dm.CalTotalSalary(employee.BasicSalary, employee.Rewards, dm.PerformanceSalary);//计算经理应发工资
            Console.WriteLine("{0}", salary);
            Console.WriteLine(employee.DisplayEmployeeInfo(employee.WorkNum,employee.Name,employee.BasicSalary,employee.Rewards));//显示员工当前信息
            //dm.DisplayEmployeeInfo(dm.NameDepart, employee.WorkNum, employee.Name, employee.BasicSalary, employee.Rewards);//显示经理当前信息
            Console.WriteLine(employee.DisplayEmployeeNumber());//显示总员工人数
        }
    }
}
