//#define Test1
//#define Test4
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#if TestStructure
struct Books
{
    public string title;
    public string author;
    public int book_id;

}

public class shape
{

}
public class testStructure
{
    public static void Main(string[] args)
    {
        Books Book1;
        Book1.title = "C Programming";
        Book1.author = "Nuha Ali";
        Book1.book_id = 6495407;
        Console.WriteLine("title {0}", Book1.title);
        Console.WriteLine("author {0}", Book1.author);
        Console.WriteLine("book_id {0}", Book1.book_id);

    }
}
#endif

#if Test2
namespace TestLink
{
    abstract class baseclass
    {
        abstract public double area();
    }

    class reactangle : baseclass
    {
        double width, lenth;
        public void setLength(double a,double b)
        {
            width = a;
            lenth = b;
        }

        public override double area()
        {
            Console.WriteLine("override is command");
            return width * lenth;
        }
    }

    class TestArea
    {
        public static void Main(string []args)
        {
            reactangle r = new reactangle();
            r.setLength(3.5, 2.4);
            Console.WriteLine("the area is " + r.area());
        }
    }
}

#endif

#if Test3
using System.Text.RegularExpressions;
namespace RegeExOpr
{
    class Program
    {
        private static void showMatch(string text,string expr)
        {
            Console.WriteLine("The Expression: " + expr);
            MatchCollection mc = Regex.Matches(text, expr);
            foreach (Match m in mc)
            {
                Console.WriteLine(m);
            }
        }

        static void Main(string[] args)
        {
            string str = "make maze and manage to measure it";
            Console.WriteLine("Matching words start with 'm' and ends with 'e':");
            showMatch(str, @"\bm\S*e\b");
            Console.ReadKey();
        }
    }
}

#endif


#if Test4
using System.IO;

namespace FileIOApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream F = new FileStream("test.dat",
            FileMode.OpenOrCreate, FileAccess.ReadWrite);

            //for (int i = 1; i <= 20; i++)
            //{
            //    F.WriteByte((byte)i);
            //}

            F.Position = 0;

            for (int i = 0; i <= 20; i++)
            {
                Console.Write(F.ReadByte() + " ");
            }
            F.Close();

            //操作windows文件系统
            DirectoryInfo mydir = new DirectoryInfo(@"c:\windows");
            FileInfo[] dirs = mydir.GetFiles();

            foreach(FileInfo f in dirs)
            {
                Console.WriteLine("File Name:{0} Size:{1}", f.Name, f.Length);
            }
            Console.ReadKey();
        }
    }
}

#endif

#if indexer
namespace IndexerApplication
{
    class IndexedNames
    {
        private string[] namelist = new string[size];
        public static int size = 10;
        public IndexedNames()
        {
            for (int i = 0; i < size; i++)
                namelist[i] = "N. A.";
        }
        public string this[int index]
        {
            get
            {
                string tmp;

                if (index >= 0 && index <= size - 1)
                {
                    tmp = namelist[index];
                }
                else
                {
                    tmp = "";
                }

                return (tmp);
            }
            set
            {
                if (index >= 0 && index <= size - 1)
                {
                    namelist[index] = value;
                }
            }
        }

        public int this[string name]
        {
            get
            {
                int index = 0;
                while (index < size)
                {
                    if (namelist[index] == name)
                        return index;
                    else
                        index++;
                }
                return index;
            }
        }
        static void Main(string[] args)
        {
            IndexedNames names = new IndexedNames();
            names[0] = "Zara";
            names[1] = "Riz";
            names[2] = "Nuha";
            names[3] = "Asif";
            names[4] = "Davinder";
            names[5] = "Sunil";
            names[6] = "Rubic";
            for (int i = 0; i < IndexedNames.size; i++)
            {
                Console.WriteLine(names[i]);
            }
            Console.WriteLine(names["Ruic"]);
            Console.ReadKey();
        }
    }
}
#endif

#if testdelegate
delegate int mydelegate(int n);
namespace DelegateApp1
{
    class TestDelegate
    {
        static int num = 10;
        public static int AddNum(int p)
        {
            num += p;
            return num;
        }
        public static int MulNum(int p)
        {
            num *= p;
            return num;
        }
        public static int getNum()
        {
            return num;
        }

        static void Main(string[] args)
        {
            //创建委托实列
            mydelegate f = new mydelegate(AddNum);
            mydelegate s = new mydelegate(MulNum);
            f(25);
            Console.WriteLine("value of f: {0}", getNum());
            s(10);
            Console.WriteLine("value of s: {0}", getNum());
            mydelegate all;
            all = f;
            all += s;
            all(5);
            Console.WriteLine("value of s: {0}", getNum());

        }
    }
}
#endif

#if testEvent
namespace eventApp
{
    class EventTest
    {
        private int value;
        public delegate void NumHandler();
        public event NumHandler changeNum;

        protected virtual void OnChangeNum()
        {
            if (changeNum != null)
                changeNum();
            else
            {
                Console.WriteLine("the event don't called");
            }
        }

        public EventTest()
        {
            OnChangeNum();
        }

        public void setValue(int value)
        {
            OnChangeNum();

        }
    }

    public class sub
    {
        public void print()
        {
            Console.WriteLine("订阅器触发");
        }
    }

    class program
    {
        public static void Main(string[] args)
        {
            EventTest e = new EventTest();
            sub s = new sub();
            e.changeNum += new EventTest.NumHandler(s.print);
            e.setValue(3);
            e.setValue(5);
        }
    }
    
}

#endif

#if TestArrayList
using System.Collections;

namespace CollectionApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList al = new ArrayList();
            Console.WriteLine("Adding some numbers:");
            al.Add(45);
            al.Add(35);
            al.Add(15);
            al.Add(55);
            al.Add(75);
            al.Add(45);

            Console.WriteLine("Capacity:{0}", al.Capacity);
            Console.WriteLine("Count:{0}", al.Count);

            Console.Write("Content: ");
            foreach (int i in al)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.Write("Sorted Content");
            al.Sort();
            foreach (int i in al)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

        }
    }
}
#endif

#if TestHashtable
using System.Collections;

namespace CollectionApplication
{
    class Program
    {
        public static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            Console.WriteLine("Adding some numbers:");
            ht.Add("001", "Zara Ali");
            ht.Add("002", "Zara Ali2");
            ht.Add("003", "Zara Ali3");
            ht.Add("004", "Zara Ali4");
            ht.Add("005", "Zara Ali5");
            ht.Add("006", "Zara Ali6");
            ht.Add("007", "Zara Ali7");

            if (ht.ContainsValue("Zara Ali8"))
            {
                Console.WriteLine("the value is contain in Hashtable");
            }
            else
            {
                ht.Add("008", "Zara Ali8");
            }
            ICollection key = ht.Keys;
            Console.WriteLine("All keys and values ");
            foreach (string k in key)
            {
                Console.WriteLine(k + " : "+ht[k]);
            }

        }
    }
}
#endif

using System.Collections.Generic;

#if TestGeneric
namespace GenericApplication
{
    public class MyGenegicArray<T>
    {
        private T[] array;
        public MyGenegicArray(int size)
        {
            array = new T[size + 1];

        }
        public T getItem(int index)
        {
            return array[index];
        }

        public void setItem(int index, T value)
        {
            array[index] = value;
        }
    }

    class Tester
    {
        static void Main(string[] args)
        {
            MyGenegicArray<int> intArray = new MyGenegicArray<int>(5);
            for (int c = 0; c < 5; c++)
            {
                intArray.setItem(c, c * 5);

            }
            for (int c = 0; c < 5; c++)
            {
                Console.Write(intArray.getItem(c) + " ");
            }
            Console.WriteLine();
            MyGenegicArray<char> charArray = new MyGenegicArray<char>(5);
            for (int c = 0; c < 5; c++)
            {
                charArray.setItem(c, (char)(c + 97));
            }
            for (int c = 0; c < 5; c++)
            {
                Console.Write(charArray.getItem(c) + " ");
            }
        }

    }
}

#endif

#if Anollymous
delegate void ChangeNumber(int x);

namespace program
{
    class test
    {
        private static int num = 10;
        public static void Add(int x)
        {
            num += x;
            Console.WriteLine("The function [Add] is called result "+num);
            num = 10;
        }

        public static void Mul(int x)
        {
            num *= x;
            Console.WriteLine("The function [Mul] is called result " + num);
            num = 10;
        }

        static void Main(string[] args)
        {
            ChangeNumber nc = delegate (int x)
            {
                Console.WriteLine("Nollymous function is " + x);
            };

            nc(15);

            nc = new ChangeNumber(Add);
            nc(20);

            nc = new ChangeNumber(Mul);
            nc(40);
        }
    }
}

#endif

#if TestUnsafe
namespace UnsafeCodeApplication
{
    class program
    {
        static  void Main(string[] args)
        {
            unsafe
            {
                int var = 20;
                int* p = &var;
                Console.WriteLine("Data is: {0}", var);
                Console.WriteLine("Adress is: {0}", (int)p);
            }
            

        }
    }
}

#endif

#if testThread
using System.Threading;

namespace MultithreadingApplication
{
    
    class MainThreadProgram
    {
        public static void calltoChildThread()
        {
            try
            {
                Console.WriteLine("Child thred starts");
                int sleepFor = 500;
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Child thred paused for {0} seconds....", (sleepFor) * (i + 1));
                    Thread.Sleep(sleepFor);
                }

                Console.WriteLine("Child thred resume");
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine("Thread Abort");

            }
            finally
            {
                Console.WriteLine("Coundn't catch the thread Exception");
            }
            
        }

        static void Main(string[] args)
        {
            Thread th = Thread.CurrentThread;
            th.Name = "MainThread";
            Console.WriteLine("This is {0}", th.Name);

            ThreadStart childref = new ThreadStart(calltoChildThread);
            Console.WriteLine("In main:Creating the Child thrad");
            Thread childth = new Thread(childref);
            childth.Start();
            Console.WriteLine("In main:Program is continue");
            Thread.Sleep(2000);
            Console.WriteLine("In main:Aborting the child thread");
            childth.Abort();

        }
    }
}
#endif

#if testInterface
interface IMyInterface
{
    void MethodToImplement();
}

class InterfaceImplementer : IMyInterface
{
    static void Main(string[] args)
    {
        InterfaceImplementer iter = new InterfaceImplementer();
        iter.MethodToImplement();
    }

    public void MethodToImplement()
    {
        Console.WriteLine("MethodToImplement be called");
    }
}

#endif
#if testEnum
namespace EnumTester
{
    class program
    {

        public enum Days : int
        {
            mon,
            two,
            thr,
            wed
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("enm : " + (int)Days.mon);
            Console.WriteLine("enm : " + (int)Days.two);
        }
    }
}

#endif

#if testDelegate
class Program
{
    public delegate void AreaDelegate(double length, double width);
    static void Main(string[] args)
    {
        Console.WriteLine("请输入长方形的长：");
        double length = double.Parse(Console.ReadLine());
        Console.WriteLine("请输入长方形的宽：");
        double width = double.Parse(Console.ReadLine());
        AreaDelegate areaDelegate = delegate
        {
            Console.WriteLine("长方形的面积为：" + length * width);
        };
        areaDelegate(length, width);
    }
}
#endif

#if testException
namespace program
{
    class MyException : Exception
    {
        public MyException(string msg) : base(msg)
        {
        }
    }

    class ExceptionTester
    {
        public static void Main()
        {
            int num;
            try
            {
                num = int.Parse(Console.ReadLine());
                if (num > 100 || num <= 0)
                {
                    throw new MyException("number is out range");
                }
            }catch(MyException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("the number is entered ");
            }
            
        }
    }
}
#endif

#if testCondition
using System;
using System.Diagnostics;
public class Myclass
{
    [Conditional("RELEASE")]
    public static void Message(string msg)
    {
        Console.WriteLine(msg);
    }
}
class Test
{
    static void function1()
    {
        Myclass.Message("In Function 1.");
        function2();
    }
    static void function2()
    {
        Myclass.Message("In Function 2.");
    }
    public static void Main()
    {
        Myclass.Message("In Main function.");
        function1();
    }
}

#endif

#if testProperty
namespace testProperty
{
    public abstract class Animal
    {
        public abstract int Age
        {
            get;
            set;
        }

        public abstract string Eat
        {
            get;
            set;
        }

        public abstract string Drink
        {
            get;
            set;
        }
    }

    public class Dog : Animal
    {
        private int age;
        private string thing;
        private string drinks;

        public override int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

        public override string Eat
        {
            get
            {
                return thing;
            }

            set
            {
                thing = value;
            }
        }

        public override string Drink
        {
            get
            {
                return drinks;
            }

            set
            {
                drinks = value;
            }
        }

        public override string ToString()
        {
            return "age " +age +",eat "+thing +",drink "+drinks;
        }
    }

    class program
    {
        public static void Main()
        {
            Dog dog = new Dog();
            dog.Age = 12;
            dog.Eat = "guapu";
            dog.Drink = "water";
            Console.WriteLine(dog);
        }
    }
}
#endif

#if testIndex
namespace spaceInde
{
    public class student
    {
        private static int iSize = 10;
        private string[] nameList = new string[iSize];

        public string this[int index]
        {
            get
            {
                if (index > 0 && index < iSize)
                {
                    return nameList[index];
                }
                else
                    return "";
            }
            set
            {
                if (index > 0 && index < iSize)
                {
                    nameList[index] = value;
                }
            }
        }

        public static void Main()
        {
            student nameOne = new student();
            for(int i = 0;i<5;i++)
            {
                nameOne[i] = "liA" + i;
            }
            Console.WriteLine("output the names");
            for(int i =0;i<5;i++)
            {
                Console.Write(" {0} ", nameOne[i]);
            }
        }
    } 
}

#endif

#if testIO
using System.IO;

namespace FileApp
{
    public class Program
    {
        public void readContent(string filePath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("the file could not be read");
                Console.WriteLine(e.Message);

            }
        }

        public void WriteContent(string filePath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        sw.WriteLine("wuxiangchao_" + i);
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine("could not open the file");
                Console.WriteLine(e.Message);
            }
        }
        public static void Main()
        {
            string filePath = "test.txt";
            Program p = new Program();
            p.readContent(filePath);
            p.WriteContent(filePath);
            p.readContent(filePath);
            Console.ReadKey();
        }
    }
}
#endif