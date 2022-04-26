using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if Debug
namespace hello
{
    class Rectangle
    {
        double lenth;
        double width;
        public void Setdetail()
        {
            lenth = 3.4;
            width = 2.5;
        }

        public double GetArea()
        {
            return lenth * width;
        }

    }

    class dataOp
    {
        public void swap(ref int a, ref int b)
        {
            int temp;
            temp = a;
            a = b;
            b = temp; 
        }


        public void changeValue(out int x)
        {

            x =  100;
        }

        public void displayArray()
        {
            int[] a = new int[10];
            for (int i = 0; i < 10; i++)
            {
                a[i] = i * 10;
            }
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("第{0} 个元素的值为{1}", i + 1, a[i]);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello world");
            //Console.ReadKey();
            /*
             * Rectangle r = new Rectangle();
            r.Setdetail();
            double area = r.GetArea();
            Console.WriteLine("面积是： "+area);
            Console.ReadKey();
            */

            /*
             * Console.WriteLine("please input a number");
            int num;
            num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("the number is " + num);
            //Console.ReadKey();
            */

            dataOp data = new dataOp();
            int a = 100, b = 200;
            Console.WriteLine("交换前a " + a + "，b " + b);
            data.swap(ref a, ref b);
            Console.WriteLine("交换后a " + a + "，b " + b);
            int x = 10;
            Console.WriteLine("修改前的x " + x);
            data.changeValue(out x);
            Console.WriteLine("修改后的x " + x);
            Console.WriteLine("展示数组");
            data.displayArray();
        }
    }
}
#endif