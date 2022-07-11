using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
//using System.Threading;

namespace ConsoleApp2
{
    internal class Program
    {
        /// <summary>
        /// 定时器
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {


            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Elapsed += Timer_Elapsed;

            Console.ReadLine();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine(DateTime.Now.Second);
        }
    }
    

}
