#define tttt

using System;
using System.Linq;
using System.Threading;

#if testWhere
class Program
{
    enum day { month,tu};
    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        //where()筛选方法
        int[] nu = { 1, 8, 6, 4, 9, 7, 3 };

        //Select usage
        Console.WriteLine("The first Usage of wehere ");
        var listtt = nu.Where(item => item % 2 == 0);
        foreach (int item in listtt)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine("The second Usage of wehere ");
        var queryLowNums = from number in nu where number < 5 select number;
        foreach (int item in queryLowNums)
        {
            Console.WriteLine(item);
        }
        string strIndex = Console.ReadLine();
        int i = 0;
        while(i<int.Parse(strIndex))
        {
            Console.WriteLine($"this is {i}");
            i++;
        }
        Console.ReadKey();
    }
}
#endif

#if testInterface
interface IParentInterface
{
    void showParentInfo();
}

interface IInterface : IParentInterface
{
    void showInfo();
}

class Program:IInterface
{
    static void Main()
    {
        Program p = new Program();
        p.showParentInfo();
        p.showInfo();
    }

    public void showParentInfo()
    {
        Console.WriteLine("this is showParentInfo function");
    }

    public void showInfo()
    {
        Console.WriteLine("this is showInfo function");
    }
}
#endif

#if testObsolete
class program
{
    [Obsolete("不要使用老方法",true)]
    static void oldFunc()
    {
        Console.WriteLine("this is in the oldFunction");
    }
    static void newFunc()
    {
        Console.WriteLine("this is in the newFunction");
    }

    static void Main()
    {
        oldFunc();
    }
}
#endif

#if testThread
class program
{
    public static void threadHandler()
    {
        try
        {
            Thread.Sleep(5000);
            Console.WriteLine("this is threadHandler");
        }
        catch(ThreadAbortException e)
        {
            Console.WriteLine(e);
        }
    }
    public static void showInfo(Object data)
    {
        string strData = (string)data;
        Console.WriteLine("the param is {0}", strData);
    }

    static void Main()
    {
        Thread th = Thread.CurrentThread;
        th.Name = "Main Thread";
        Console.WriteLine($"the thread is {th.Name}");

        //不带参数的线程
        ThreadStart startTh = new ThreadStart(threadHandler);
        Thread ChildTh = new Thread(startTh);
        ChildTh.Start();
        //ChildTh.Abort(); //终止线程

        //带参数开辟线程
        Thread ChildTh2 = new Thread(new ParameterizedThreadStart(showInfo));
        ChildTh2.IsBackground = true;
        ChildTh2.Start("hello world");
        Console.WriteLine("the Main thread is over");
    }
}
#endif

class program
{
    public static void Main(string [] args)
    {
        ThreadPool.QueueUserWorkItem(testMethod, "Hello");
        //Console.ReadKey();
    }

    public static void testMethod(object data)
    {
        string strData = (string)data;
        Console.WriteLine(strData);
    }
}