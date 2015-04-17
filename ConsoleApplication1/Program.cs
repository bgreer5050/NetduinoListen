using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();
        }
    }

    public class Test
    {

        public Test()
        {
            Thread thread = new Thread(Monitor);
            thread.Start();
        }

        public void Monitor()
        {
            while(true)
            {
                Console.WriteLine("Test");
                System.Threading.Thread.Sleep(3000);
            }
        }

    }
}
