using System;
using System.Threading;
using System.Threading.Tasks;


namespace SecondTest
{
    #region TestIndex
    public class TestIndex
    {
        public int size;
        public string[] names;
        public TestIndex(int size)
        {
            this.size = size;
            names = new string[size];
            for (int i = 0; i < size; i++)
            {
                names[i] = "liWei";
            }
        }
        public string this[int index]
        {
            get
            {

                if (index < 0 || index >= size)
                {
                    Console.WriteLine("out of range");
                    return null;
                }
                else
                    return names[index];
            }
            set
            {
                if (index < 0 || index >= size)
                    Console.WriteLine("set out of range");
                else
                    names[index] = value;
            }
        }
    }
    public class MyException : ApplicationException
    {
        public MyException(string e) : base(e) { }
    }

    public class Prograss
    {
        public void show()
        {
            throw (new MyException("this is a exception"));
        }
    }
    #endregion
    public class TestEvent
    {
        public delegate void TestHandler(string str);
        public event TestHandler onChange;
        private int testValue;
        public TestEvent()
        {
            testValue = 5;
            SetValue(testValue);
        }
        public void SetValue(int val)
        {
            if (val != testValue)
                changeStr(val);
        }
        public void changeStr(int val)
        {
            if (onChange != null)
            {
                onChange("this val is " + val);
            }
        }
    }
    public class Subscribe
    {
        public void printf(string str)
        {
            Console.WriteLine(str);
        }

        public enum Member
        {
            gold,
            silver,
            copper
        }
        public struct classStu
        {
            string name;
            int age;
            public void SetVal(string Vname, int Vage)
            {
                name = Vname;
                age = Vage;
            }
            public void ShowVal()
            {
                Console.WriteLine("name is " + name);
                Console.WriteLine("age is " + age);
            }
        }
    }



    public class HelpAttribute : Attribute
    {
        public HelpAttribute(string Des)
        {
            this.desc = Des;
        }
        protected String desc;
        public String Desc
        {
            set
            {
                this.desc=value;
            }
            get
            {
                return this.desc;
            }
        }
    }

    [HelpAttribute("this is a Attribute Test")]
    public class TestDesc
    {
        public static void show()
        {
            Console.WriteLine("this is a tester");
        }
    }
    class Program
    {
        
        static void Main(string[] path)
        {
            //Console.WriteLine("Hello World!");
            //try 
            //{
            //    Prograss p = new Prograss();
            //    //p.show();
            //}
            //catch (MyException e)
            //{
            //    Console.WriteLine("Mess : {0}",e);
            //}
            //TestIndex tester = new TestIndex(10);
            //for(int i=0;i<6;i++)
            //{
            //    tester[i] = "zhang_" + i + 1;
            //}
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(tester[i]);
            //}

            //TestEvent testEvent = new TestEvent();
            //Subscribe subscribe = new Subscribe();
            //testEvent.onChange += new TestEvent.TestHandler(subscribe.printf);
            //testEvent.SetValue(10);
            //testEvent.SetValue(20);

            //Console.WriteLine("启动任务");
            //Task t = new Task(() =>
            //{
            //    Console.WriteLine("任务开始工作……");
            //    //模拟工作过程
            //    Thread.Sleep(5000);
            //});
            //t.Start();
            //Console.WriteLine("t.start...");
            //t.ContinueWith((task) =>
            //{
            //    Console.WriteLine("任务完成，完成时候的状态为：");
            //    Console.WriteLine("IsCanceled={0}\tIsCompleted={1}\tIsFaulted={2}",
            //                      task.IsCanceled, task.IsCompleted, task.IsFaulted);
            //});

            Func<string, int, bool> Test0 = (a, b) =>
              {
                  Console.WriteLine("name " + a + " age: " + b);
                  if (Convert.ToInt32(b) < 18)
                      return false;
                  else
                      return true;
              };
            var temp = Test0("libai", 21);
            Console.WriteLine("成年人：{0} ", temp);

            Console.WriteLine(Enum.GetName(typeof(Subscribe.Member), 1));

            int m = 2, n = 5;
            if (m == 2)
                Console.WriteLine("m<2");
            else if (n == 5)
                Console.WriteLine("n==5");
            else
                Console.WriteLine("nothing");

            Subscribe su = new Subscribe();
            Subscribe.classStu cc = new Subscribe.classStu();
            cc.ShowVal();

            Console.WriteLine(Subscribe.Member.gold);

            TestDesc.show();
            System.Reflection.MemberInfo info = typeof(TestDesc);
            object[] attributes = info.GetCustomAttributes(true);
            foreach( var att in attributes)
            {
                Console.WriteLine(att);
            }
            Console.WriteLine(nameof(cc));
        }
    }
}
