3、ListView控件基本操作。
要求设置ListView控件外观、添加项、删除项和获取选中项改变事件。

 
图2  程序运行效果图

实验过程和要求：
（1）添加ListView等控件（以下只说明ListView的设置）；其中”年龄”后面的控件采用“NumericUpDown”控件。
（2）设置ListView外观
1）打开ListView控件的属性面板，首先设置View属性的属性值为Details。
2）然后设置各列标题，找到Columns属性，单击其右侧的“…”图标，如图2所示。弹出ColumnHeader（列标题）集合编辑器对话框，如图3所示。在该对话框中可以编辑各列标题、各列宽度以各列的显示顺序等。单击对话框左侧的【添加】按钮，即可添加一个列，默认名称为columnHeader1，然后在对话框右侧可以设置该列的Text显示文本、Width宽度等属性，还可以通过DisplayIndex属性设置各列的显示顺序。

  
图3 设置Columns属性

 
图4 ColumnHeader集合编辑器

3）设置各列标题后的ListView控件如图4所示，从图中可以看到ListView控件已经显示各列的标题，但是没有显示单元格分隔线条（网络线）。设置GridLine属性的属性值为True，可以显示ListView网格线，如图5所示。

 
 图5 设置列标题后的ListView控件 

 
图6 设置GridLine属性后的ListView控件

4）设置ListView控件的其他属性，分别设置FullRowSelect属性的属性值为True，设置MultiSelect属性的属性值为False，外观与普通表格相同。
（3）编写代码。
如果要为列表项添加一行，应使用如下代码：（如果是从其他途径获得数据，只需要修改实参就好）
 
删除行使用以下代码：

 
