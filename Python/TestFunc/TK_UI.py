import  tkinter as tk
on_hit = False


def hit_me():
    global on_hit
    if on_hit ==False:
        on_hit = True
        var.set("you hit me")
        l.config(bg='blue')
    else:
        on_hit = False
        var.set("")
        l.config(bg='red')

if __name__=="__main__":

    window = tk.Tk();
    window.title("My window")
    window.geometry("200x100")
    var = tk.StringVar()
    var.set("OMG! this is TK!")
    l = tk.Label(window,
                 textvariable=var,  # 标签的文字
                 bg='green',  # 背景颜色
                 font=('Arial', 12),  # 字体和字体大小
                 width=15, height=2  # 标签长宽
                 )
    l.pack()

    b= tk.Button(window,text='hit me',width=15,height=2,command=hit_me)
    b.pack()

    e = tk.Entry(window,show="*")
    e.pack()

    t = tk.Text(window,height=2)
    t.pack()

    #var = e.get()
    #t.insert('insert',var)
    #t.insert('end',var)
    #t.insert(2.2,var)

    var2 = tk.StringVar()
    var2.set((11, 22, 33, 44))  # 为变量设置值

    # 创建Listbox
    lb = tk.Listbox(window, listvariable=var2)  # 将var2的值赋给Listbox

    # 创建一个list并将值循环添加到Listbox控件中
    list_items = [1, 2, 3, 4]
    for item in list_items:
        lb.insert('end', item)  # 从最后一个位置开始加入值

    lb.insert(1, 'first')  # 插入操作，在第一个位置加入'first'字符
    lb.insert(2, 'second')  # 在第二个位置加入'second'字符
    lb.delete(2)  # 删除操作，删除第二个位置的字符
    lb.pack()


    #单选框
    varSingle = tk.StringVar()
    l = tk.Label(window, bg='yellow', width=20, text='empty')
    l.pack()

    def print_selection():
        l.config(text='you have selected ' + varSingle.get())  # var.get()即获取到变量 var 的值


    r1 = tk.Radiobutton(window, text='Option A', variable=varSingle, value='A', command=print_selection)
    r1.pack()
    r2 = tk.Radiobutton(window, text='Option B', variable=varSingle, value='B', command=print_selection)
    r2.pack()
    r3 = tk.Radiobutton(window, text='Option C', variable=varSingle, value='C', command=print_selection)
    r3.pack()

    window.mainloop()
