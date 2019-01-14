using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Games._1._Manage_programm_flow._1._1._Implementing_multithreading_and_async_processing
{
    [TestClass]
    public class ThreadingTests
    {
        [ThreadStatic]
        private static int v = 0;

        public static void ThreadMethod1()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine($"ThreadProc 1 : {i}");
                v++;
                Thread.Sleep(0);
            }
        }

        public static void ThreadMethod2()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine($"ThreadProc 2 : {i}");
                v++;
                Thread.Sleep(0);
            }
        }

        [TestMethod]
        public void Case_1_TwoParallelThreads()
        {
            var thread1 = new Thread(ThreadMethod1);
            thread1.Start();

            var thread2 = new Thread(ThreadMethod2);
            thread2.Start();

            thread1.Join();

            Console.WriteLine($"final value: {v}");
        }

        [TestMethod]
        public void Case_2_ThreadPool()
        {
            ThreadPool.QueueUserWorkItem(s =>
            {
                Console.WriteLine("Working on a thread from threadpool");
            });
        }
    }
}
