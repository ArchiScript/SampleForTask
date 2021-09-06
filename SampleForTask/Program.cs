using System;
using System.Threading.Tasks;
using System.Threading;
namespace SampleForTask
{
    class Program
    {
        static void Main(string[] args)
        {
            /* var task1 = new Task(() => Console.WriteLine("Message"));
             var task2 = new Task(Print);
             task1.Start();
             var task3 = Task.Factory.StartNew(() => Console.WriteLine("Print task3"));
             var task4 = Task.Run(() => Console.WriteLine("Print task4"));
             task3.Wait();*/

            var task5 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("wrapper task start");
                var task6 = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("message from wrapped task");
                    Thread.Sleep(1000);
                    Console.WriteLine("wrapped task complete");
                },TaskCreationOptions.AttachedToParent);

                Console.WriteLine("message from wrapper task");
                Thread.Sleep(1000);
                Console.WriteLine("wrapper task complete");
            });
        }
        public static void Print()
        {
            Console.WriteLine("Message by method");
        }
    }
}
