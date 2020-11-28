类的继承特征

（1）编写应用程序，初步实现员工信息管理的功能

　　1）  定义一个员工类Employee，员工类中包括私有成员：workNum（工号）、name（姓名）、basicSalary（基本工资）、rewards（奖金）、employeeNum（静态成员：总员工人数）；
　　2）  在类中添加公有方法：CalTotalSalary（计算应发工资，基本工资+奖金）、DisplayEmployeeInfo（显示员工当前信息）、DisplayEmployeeNumber（显示总员工人数）
　　3）  在类Employee中添加相应的公有属性，WorkNum（工号）、Name（姓名）、BasicSalary（基本工资）、Rewards（奖金）、Salary（应发工资，只读）；
　　4）  类中同时包含函数：Employee（构造函数）、~Employee（析构函数）。其中，构造函数为Employee类的对象赋值并将员工人数加1，以实现对象的初始化，析构函数计算员工人数减1，显示当前人数信息。
　　5）  创建一个类Employee的对象并调用四个公有方法。
　　6） 创建一组类Employee的对象并调用相应的方法设置和显示各对象信息。（提示：可以通过创建ArrayList类对象，每创建一个Employee对象，通过ArrayList的add方法将对象加到列表中） 

（2）基于（1）题中的员工类派生定义部门经理类DepartManager：
　　1）  定义私有成员：nameDepart（部门名称）、performanceSalary（经理绩效工资）
　　2）  定义构造函数和析构函数，构造函数DepartManager（）初始化经理类成员，析构函数~ DepartManager（）显示当前经理离职信息
　　3）  在类DepartManager中添加相应的公有属性，NameDepart（部门名称，只读）、PerformanceSalary（经理绩效工资）
　　4）  重写方法CalTotalSalary（计算经理应发工资，基本工资+奖金+经理绩效工资）
　　5）  重写方法DisplayEmployeeInfo（显示经理当前信息）
　　6）  创建DepartManager的对象dm并调用新定义的两个公有方法
　 7） 试着把dm也加到数组列表中，并将Employee类中的DisplayEmployeeInfo前面加virtual，将DepartManager类中的DisplayEmployeeInfo前加override，看看运行结果如何，思考一下，它反映了面向对象编程中的什么特征？（将思考结果作为注释写在该方法的定义之前）
