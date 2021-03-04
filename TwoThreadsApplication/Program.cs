using System;
using System.Threading;
using TwoThreadsApplication.dbmodels;
using System.Linq;
using System.Threading.Tasks;

namespace TwoThreadsApplication
{
    class Program
    {
      static  PetShelterContext context;
        static void Main(string[] args)
        {
           context = new PetShelterContext();
            Console.WriteLine("Hello World!");
            Program p = new Program();

            //Thread t1 = new Thread(p.Method1);
            //Thread t2 = new Thread(p.Method2);

            // t1.Start();
            // t2.Start();

            //  Task task1 = Task.Factory.StartNew(() => p.Method1());
            //  Task task2 = Task.Factory.StartNew(() => p.Method2());
            ////  Task task3 = Task.Factory.StartNew(() => doStuff("Task3"));
            //  Task.WaitAll(task1, task2);

            Parallel.Invoke(() =>
            {
                p.Method1();
            }, () =>
            {
                p.Method2();
            }

            );

            

            Console.WriteLine("All threads complete");
            Console.ReadLine();

            Console.ReadKey();

        }

        public void Method1()
        {
            //insert values...
            
            var pets = context.Petshelter.ToList();
            //Thread.Yield();
           foreach(var a in pets)
            {
                Console.WriteLine(a.Id);
                
            }
        }

        public void Method2()
        {
            //PetShelterContext context = new PetShelterContext();
            //var pets = context.Petshelter.ToList();
            ////Thread.Yield();

            //foreach (var a in pets)
            //{
            //    Console.WriteLine(a.Id);
            //}

            for(int i=0;i<=1000;i++)
            {
                Console.WriteLine("Method2"+i);
            }

        }
    }

   
}
