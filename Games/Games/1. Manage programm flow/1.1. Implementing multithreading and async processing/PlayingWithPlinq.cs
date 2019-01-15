using System;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Games._1._Manage_programm_flow._1._1._Implementing_multithreading_and_async_processing
{
    [TestClass]
    public class PlayingWithPlinq
    {
        [TestMethod]
        public void PrintEvenNumbersBeforeTenInParallel()
        {
            var numbersBeforeTen = Enumerable.Range(0, 10);
            var evenNumbersBeforeTen = numbersBeforeTen.AsParallel()
                                                       .Where(i => i % 2 == 0);

            foreach (var i in evenNumbersBeforeTen)
            {
                Console.WriteLine(i);
            }
        }
    }
}
