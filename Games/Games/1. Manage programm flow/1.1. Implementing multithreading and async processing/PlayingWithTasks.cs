using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Games._1._Manage_programm_flow._1._1._Implementing_multithreading_and_async_processing
{
    [TestClass]
    public class PlayingWithTasks
    {
        [TestMethod]
        public void _1_Case()
        {
            var task = Task.Run(() =>
            {
                for (var i = 0; i < 100; i++)
                {
                    Console.Write($"{i + 1} ");
                }
            });
        }

        [TestMethod]
        public void _2_Case()
        {
            var task = Task.Run(() => 42);

            Console.WriteLine(task.Result);
        }

        [TestMethod]
        public void _3_Case()
        {
            var results = new int[3];
            var parent = Task.Run(() =>
            {
                new Task(() => results[0] = 0, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = 1, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = 2, TaskCreationOptions.AttachedToParent).Start();

                return results;
            });

            var finalTask = parent.ContinueWith(parentTask =>
            {
                foreach (var i in parentTask.Result)
                    Console.WriteLine(i);
            });
        }

        [TestMethod]
        public void _4_Case()
        {
            var tasks = new Task[3];

            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });


            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("2");
                return 2;
            });

            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("3");
                return 3;
            });

            Task.WaitAll(tasks);
        }

        [TestMethod]
        public void _5_Case()
        {
            var tasks = new Task<int>[3];

            tasks[0] = Task.Run(() => { Thread.Sleep(2000); return 1; });
            tasks[1] = Task.Run(() => { Thread.Sleep(1000); return 2; });
            tasks[2] = Task.Run(() => { Thread.Sleep(3000); return 3; });


            while (tasks.Length > 0)
            {
                var i = Task.WaitAny(tasks);
                var completedTask = tasks[i];
                Console.WriteLine(completedTask.Result);

                var temp = tasks.ToList();
                temp.RemoveAt(i);

                tasks = temp.ToArray();
            }
        }
    }
}