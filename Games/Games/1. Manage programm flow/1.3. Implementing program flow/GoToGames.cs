using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Games._1._Manage_programm_flow._1._3._Implementing_program_flow
{
    [TestClass]
    public class GoToGames
    {
        [TestMethod]
        public void TestOne()
        {
            var x = 3;
            if (x == 3)
            {
                goto customLabel;
            }

            Console.WriteLine("before goto");

            customLabel:
            Console.WriteLine("go here");
        }
    }
}
