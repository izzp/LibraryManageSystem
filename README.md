# 图书馆管理系统

------

##大二上学期期末c#实训小组项目：
### 仅供代码参考，源码已去除敏感接口信息，故一些功能不可使用
实训使用到的开发平台，工具，及开放技术
> * 阿里云短信推送
> * 阿里云邮件推送
> * OSS对象存储
> * 百度AI
> * 阿里云ECS用作远程SQL数据库
> * 腾讯云开发者平台
> * 坚果云同步

------

## 效果图
![7](https://cdn.jsdelivr.net/gh/izzp/LibraryManageSystem/img/7.png)
![1](https://cdn.jsdelivr.net/gh/izzp/LibraryManageSystem/img/1.png)
![2](https://cdn.jsdelivr.net/gh/izzp/LibraryManageSystem/img/2.png)
![3](https://cdn.jsdelivr.net/gh/izzp/LibraryManageSystem/img/3.png)
![5](https://cdn.jsdelivr.net/gh/izzp/LibraryManageSystem/img/5.png)
![6](https://cdn.jsdelivr.net/gh/izzp/LibraryManageSystem/img/6.png)
![1](https://cdn.jsdelivr.net/gh/izzp/LibraryManageSystem/img/6.png)
![1](https://cdn.jsdelivr.net/gh/izzp/LibraryManageSystem/img/8.png)
![1](https://cdn.jsdelivr.net/gh/izzp/LibraryManageSystem/img/9.png)
![1](https://cdn.jsdelivr.net/gh/izzp/LibraryManageSystem/img/10.png)
![1](https://cdn.jsdelivr.net/gh/izzp/LibraryManageSystem/img/11.png)
![1](https://cdn.jsdelivr.net/gh/izzp/LibraryManageSystem/img/12.png)
![1](https://cdn.jsdelivr.net/gh/izzp/LibraryManageSystem/img/13.png)
![1](https://cdn.jsdelivr.net/gh/izzp/LibraryManageSystem/img/14.png)
![1](https://cdn.jsdelivr.net/gh/izzp/LibraryManageSystem/img/15.png)
![1](https://cdn.jsdelivr.net/gh/izzp/LibraryManageSystem/img/16.png)
![1](https://cdn.jsdelivr.net/gh/izzp/LibraryManageSystem/img/17.png)


## 系统功能描述
为了操作人员使用本系统更加的便利，本系统的功能模块分为以下操作：

- [x] 管理员管理：包括管理员添加信息和登陆切换，该模块主要是对管理员信息的增删改操作；
- [x] 读者管理：包括读者信息的注册、修改、删除、查询，该模块主要是对读者信息的增删改查操作；
- [x] 书籍管理：包括新书的入库和书籍的查询，该模块主要是对书籍的记录和查询；
- [x] 书籍借阅归还：包括借阅书籍和归还书籍两个功能，该模块主要是对书籍和读者信息的增加和删除。


## 窗体说明

|窗体名称	|说明|
| --------   | -----:  |
|Login|	用户登陆界面|
|ALogin	|管理员登陆界面|
|Register|	读者注册界面|
|ResetPW|	找回密码界面|
|ReaderMain|	用户主界面|
|Main|	管理员主界面

## 数据库设计：
数据库包含3个数据表，分别为用户（读者，管理员）信息表（UserInfo），图书表（Books），借阅表（BRBooks）

### 用户（读者，管理员）信息表（UserInfo）

|字段名称|	数据类型|	长度|	允许为空|	说明|
| --------   | -----:  | -----:  | -----:  |-----:  |
|UserAccount|	Nvarchar|	50	|否	|登录账号(主键)|
|UserPassword|	Nvarchar|	50|	否	|登录密码|
|UserType|	Nvarchar|	50|	否|	权限类型|
|UserName|	Nvarchar|	50|	否|	姓名|
|UserMobile |	Nvarchar|	50|	否|	手机号|
|UserEmail|	Nvarchar|	50|	否|	电子邮箱|

### 图书表（Books）

|字段名称|	数据类型|	长度|	允许为空|	说明|
| --------   | -----:  | -----:  | -----:  |-----:  |
|ISBN	|Nvarchar|	50|	否|	书号（主键）|
|BookName|	Nvarchar|	50|	否|	书名|
|Bookstyle|	Nvarchar|	50|	否|	图书类型|
|Price	|Float	|	|否|	价格|
|Press|	Nvarchar|	50|	否|	出版社|
|Author	|Nvarchar|	50|	否|	作者|
|EnterTime|	Date|	|	否|	购入时间|
|IsBorrow|	Nvarchar|	50|	否|	是否借出|


### 借阅表（BRBooks）

|字段名称|	数据类型|	长度|	允许为空|	说明|
| --------   | -----:  | -----:  | -----:  |-----:  |
|UserNum|	Nvarchar|	50|	否|	登录账号（外键）|
|ISBN|	Nvarchar|	50|	否|	书号（外键）|
|ReturnTime|	Date|	|	否|	归还时间|
|BorrowTime|	Date|	|	否|	借出时间|

## 过程 

```gantt
    title 实训过程
        写文档       :a1, 2019-01-14, 1d
        写主体框架     :2019-01-15, 1d
        分块写       : 2019-01-16, 1d
        基本完善及测试      :2019-01-17, 2d
        最后演示        :2019-01-19, 1d
```
## 其它内容看图
------
2019 年 01月 20日    



