using System;
using System.Threading.Tasks;
using System.Threading;
namespace SampleForTask
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            /* var task1 = new Task(() => Console.WriteLine("Message"));
             var task2 = new Task(Print);
             task1.Start();
             var task3 = Task.Factory.StartNew(() => Console.WriteLine("Print task3"));
             var task4 = Task.Run(() => Console.WriteLine("Print task4"));
             task3.Wait();*/


            /*var task5 = Task.Factory.StartNew(() =>
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
            });*/

            /* var task7 = Task<int>.Run(() => GetSum(5, 3));
             Console.WriteLine(task7.Result);*/


            for (int i = 0; i < 10; i++)
            {
                Reader reader = new Reader(i);
            }
            Console.ReadLine();
        }


        /*public static void Print()
        {
            Console.WriteLine("Message by method");
        }

        private static int GetSum(int a, int b)
        {
            return a + b;
        }

        private static void Test(CancellationToken cancellationToken)
        {
            var task8 = Task.Factory.StartNew(() =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    Thread.Sleep(200);
                    Console.WriteLine("x");
                }


            });
        }*/
        


    }
    class Reader
    {
        // семафор
        static Semaphore semaphore = new Semaphore(4,4);
        Thread thread;
        int count = 3; // счетчик

        public Reader(int i)
        {
            thread = new Thread(Read);
            thread.Name = $"Читатель {i}";
            thread.Start();
        }

        public void Read()
        {
            while (count>0)
            {
                semaphore.WaitOne();
                Console.WriteLine($"{Thread.CurrentThread.Name} входит в библиотеку");

                Console.WriteLine($"{Thread.CurrentThread.Name} читает");
                Thread.Sleep(1000);

                Console.WriteLine($"{Thread.CurrentThread.Name} покидает библиотеку");

                semaphore.Release();
                count--;
                Thread.Sleep(1000);
            }
        }
    }

    
}
