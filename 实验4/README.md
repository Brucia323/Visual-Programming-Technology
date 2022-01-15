# 实验四  Windows窗体应用程序设计

## 一、实验目的

1. 熟悉Windows窗体应用程序设计步骤
1. 熟悉WinForm窗体界面元素
1. 熟练掌握WinForm窗体界面设计，灵活运用界面元素布局窗体
1. 熟悉各种元素的属性方法以及事件触发机制。

## 二、实验时间和地点

  学时：2学时

## 1 实验内容和要求

1. 创建一个Windows窗体应用程序，创建一个登陆界面，如果登录成功，进入第2题界面。
![](https://cdn.nlark.com/yuque/0/2022/png/23075474/1642215873902-f8c1f780-e62d-4056-b029-059ff2043782.png#crop=0&crop=0&crop=1&crop=1&id=C7zyk&originHeight=900&originWidth=1600&originalType=binary&ratio=1&rotation=0&showTitle=false&status=done&style=none&title=)
2. 在项目中添加一个Form，加入富文本控件，并设置选中文本的字体，字号，颜色，风格等等。如下图所示。
![](https://cdn.nlark.com/yuque/0/2022/png/23075474/1642215874434-9030210e-f668-4cdd-b94f-2b906969b7cc.png#crop=0&crop=0&crop=1&crop=1&id=oRJGo&originHeight=900&originWidth=1440&originalType=binary&ratio=1&rotation=0&showTitle=false&status=done&style=none&title=)
3．完成书本P247的例题9.16，体会将多个事件连接到单个事件。
4．设计并实现以下界面：
![](https://cdn.nlark.com/yuque/0/2022/png/23075474/1642215874899-16f69c8c-35e2-49eb-aec9-225fd521abf7.png#crop=0&crop=0&crop=1&crop=1&id=mj6wF&originHeight=422&originWidth=887&originalType=binary&ratio=1&rotation=0&showTitle=false&status=done&style=none&title=)

实验过程：
（1）新建工程
（2）根据上图在Form1窗体上添加组件，并设置属性

（3）在“解决方资源管理器”中，右键解决方案，“添加”——“新建项目” ，在弹出的窗口里选择“类库”，命名为“Models”
修改Class1.cs名称为“Room.cs”
参考上面的界面为“Room”类添加字段和属性
其中房间名称只读，来源于建筑名称+楼层+号码
根据楼宇名称确定楼层选项，如“A”楼有02-16层，B有03-25层，等
根据楼宇名称和楼层确定房间号，如A16的房间号为“01，02，03，05，06，08，16，18，22，28”，而A08层在房间号有：“01，02，03，05，06，08，，09，10，12，16，17，18，19，20，21，22，23，25，26，28，29，30”
房间类型只能选择得到：“空闲”，“已入住”“打扫中”“维修中”“未启用”等状态，默认为“空闲”。
（4）在“解决方资源管理器”中，右键解决方案，“添加”——“新建项目” ，在弹出的窗口里选择“类库”，命名为“DALS”；右键，“添加引用”——“Models”

- 新建一个类，名为”DateWork.cs”，添加如下代码：

```csharp
public static DataSet ds = new DataSet();
```

修改Class1.cs名称为“RoomDA.cs”
为该 类添加方法

```csharp
DataTable dt = new DataTable("rooms");
public RoomDA()
{

    DataWork.ds.Tables.Add(dt);
    dt.Columns.Add("房间名", Type.GetType("System.String"));
    dt.Columns.Add("所在楼宇", Type.GetType("System.String"));
    dt.Columns.Add("所在楼层", Type.GetType("System.String"));
    dt.Columns.Add("房间号", Type.GetType("System.String"));
    dt.Columns.Add("房间类型", Type.GetType("System.String"));
    dt.Columns.Add("说明", Type.GetType("System.String"));
    dt.Columns.Add("状态", Type.GetType("System.String"));
    dt.Columns.Add("定价", Type.GetType("System.String"));
}
public string  AddRoom(Models.Room room)
{

    if(IsRoomExist(room) ) 
        return "该房间已经-存在！";
    DataRow row = dt.NewRow();
    row[0] = room.RoomName;
    row[1] = room.BuildingName;
    row[2] = room.Floor;
    row[3] = room.Num;
    row[4] = room.RoomType;
    row[5] = room.Memo;
    row[6] = room.RoomStatus;
    dt.Rows.Add(row);
    return "添加成功|";
}
public bool IsRoomExist(Models.Room room)
{
    bool flag = false;
    foreach (DataRow dr in dt.Rows)
        if (room.RoomName == dr[0].ToString()) { flag = true; break; }
    return flag;
}
```

1. 为Form1所在的项目添加引用，方法同上一步，将Models和DALS都添加

在Form1中添加代码：

```csharp
DALS.RoomDA rd = new DALS.RoomDA();
```

        在“增加”按钮的Click事件中添加代码：

```csharp
Models.Room room = new Models.Room();
room.BuildingName=this.comboBox1.Text;
room.Floor=this.comboBox2.Text;
room.Num=this.comboBox3.Text;
textBox1.Text=room.RoomName;
room.RoomType=comboBox4.Text;
room.Memo=textBox2.Text;
room.RoomStatus=comboBox5.Text;

Label8.Text=rd.AddRoom(room);
dataGridView1.DataSource = DALS.DataWork.ds.Tables[0];
```

（6）保存，运行

## 四、实验总结
