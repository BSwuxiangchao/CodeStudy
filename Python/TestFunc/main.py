# 这是一个示例 Python 脚本。

# 按 Shift+F10 执行或将其替换为您的代码。
# 按 双击 Shift 在所有地方搜索类、文件、工具窗口、操作和设置。
import sys
from keyword import kwlist
from pathlib import Path
import os
import tkinter as tk


def PrintMyPythonInfo():
    print(kwlist);[
        print(sys.version)
    ]


def Add(a, b)->int:
    return a+b

def Max(*param):
    temp = param[0]
    for i in param:
        print(i)
        if temp<i:
            temp =i
    return temp

def TestLambda(a,b):
    add = lambda a,b:a+b
    return add(a,b)

def print_hi(name):
    # 在下面的代码行中使用断点来调试脚本。
    print(f'Hi, {name}')  # 按 Ctrl+F8 切换断点。
    msg="welcome %s Enter the chatroom"%name
    print(msg)

def cin():
    str = input("请输入一个数字:")
    return str

def FileWriter(name):
    my_file = Path(name);
    if my_file.exists():
        print("%s is exist"%name)
        file = open(name,'w')
        file.write("hello ,My name is wxc")
        file.close()
    else:
        print("%s is not exist"%name)
        return
def FileReader(name):
    my_file=Path(name);
    if my_file.exists():
        try:
            print("%s is exist" % name)
            file = open(name, 'r')
            '''
            while True:
                str = file.readline()
                if not str:
                    break
                else:
                    print(str,end="")
            '''
            str = file.read()
            print(str)
        except :
            print("read file error")
        finally:
            file.close()
    else:
        print("%s is not exist"%name)

class Base:
    def __init__(self,name):
        print(name)

class CodePro(Base):
    price =0
    def __init__(self,name):
        super().__init__(name)

    def showInfo(self):
        print("this is a class")

# 按间距中的绿色按钮以运行脚本。
if __name__ == '__main__':
    """
    print_hi('PyCharm')
    print(f'count is {Add(2,4)}')
    print(f'num is {cin()}')
        print(sys.argv)
    
    print("最大值%d"%(Max(2,34,5,1)))
    print("addLambda 's value %d"%TestLambda(3,5))
    """
    #FileWriter("test.txt")
    FileReader("test.txt")
    CodePro.price = 10
    print("CodePro.price %d"%CodePro.price)
    code = CodePro("libai")
    code.showInfo()
    code.price =20
    print("A CodePro.price %d"%code.price)




# 访问 https://www.jetbrains.com/help/pycharm/ 获取 PyCharm 帮助
