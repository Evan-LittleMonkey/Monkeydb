using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_T1
{
    //1、定义委托
    delegate void HelpDelegate();
    class Program
    {
        static void Main(string[] args)
        {       
            for (int i = 0; i < 100; i++)
            {
                bool flag = false;
                Random r = new Random();
                int x = r.Next();
                flag=(x % 3 == 0);
                Watch(flag);
                if (flag)
                {
                    break;
                }
                System.Threading.Thread.Sleep(2000);
            }
            Console.ReadKey();
        }

        static void Watch(bool flag)
        {
            if (flag)
            {
                //创建委托，通知小伙伴
                HelpDelegate help = new HelpDelegate(Notify);
                //多播委托，自己逃跑
                help += new HelpDelegate(Run);
                help();
                
            }
            else
            {
                Console.WriteLine("安全");
            }
        }

        static void Notify()
        {
            Console.WriteLine("Tom来了，快跑！！！");
        }

        static void Run()
        {
            Console.WriteLine("Jerry在逃跑");
        }
    }
}
