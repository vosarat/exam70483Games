using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Games._1._Manage_programm_flow._1._1._Implementing_multithreading_and_async_processing
{
    [TestClass]
    public class PlayingWithConcurrentBag
    {
        [TestMethod]
        public void TestMethod1()
        {
            var bag = new ConcurrentBag<int>();

            bag.Add(42);
            bag.Add(21);
            bag.Add(105);
            bag.Add(89);

            if (bag.TryTake(out var result))
            {
                Console.WriteLine(result);
            }

            if (bag.TryPeek(out result))
            {
                Console.WriteLine(result);
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            var bag = new ConcurrentBag<int>();

            Task.Run(() =>
                     {
                         bag.Add(42);
                         Thread.Sleep(1000);
                         bag.Add(21);
                     });

            foreach (var i in bag)
            {
                Console.WriteLine(i);
            }
        }

        [TestMethod]
        public void TestMethod2_WithList()
        {
            var list = new List<int>();

            Task.Run(() =>
                     {
                         list.Add(42);
                         Thread.Sleep(1000);
                         list.Add(21);
                     });

            //Console.WriteLine("start");

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
        }
    }
}
