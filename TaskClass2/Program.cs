using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskClass2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Demo8();
        }

        private static void Demo1()
        {
            // Exception 1
            var elements = Enumerable.Range(0, 100).ToList();
            foreach (var item in elements)
            {
                Console.WriteLine(item); ;

                if (item > 0 && item % 20 == 0)
                {
                    elements.Add(999);
                }
            }
        }

        private static void Demo2()
        {
            // Exception 2
            var elements = Enumerable.Range(0, 100).ToList();

            var t1 = Task.Run(() =>
            {
                Thread.Sleep(1000);
                for (int i = 0; i < 100; ++i)
                {
                    elements.Add(i + 1000);
                    Thread.Sleep(100);
                }
            });

            var t2 = Task.Run(() =>
            {
                foreach (var item in elements)
                {
                    Console.WriteLine(item);
                    Thread.Sleep(150);
                }
            });

            try
            {
                Task.WaitAll(t1, t2);
            }
            catch (AggregateException ex) // No exception
            {
                Console.WriteLine(ex.Flatten().Message);
            }
        }

        private static void Demo3()
        {
            // ConcurrentQueue (with foreach)
            var elements = Enumerable.Range(0, 20).ToList();
            var coll = new ConcurrentQueue<int>(elements);
            coll.Enqueue(999);

            var t1 = Task.Run(() =>
            {
                for (int i = 0; i < 20; ++i)
                {
                    coll.Enqueue(i + 100);
                    Thread.Sleep(100);
                }
            });

            var t2 = Task.Run(() =>
            {
                Thread.Sleep(300);
                foreach (var item in coll)
                {
                    Console.WriteLine(item);
                    Thread.Sleep(150);
                }
            });

            try
            {
                Task.WaitAll(t1, t2);
            }
            catch (AggregateException ex) // No exception
            {
                Console.WriteLine(ex.Flatten().Message);
            }
        }

        private static void Demo4()
        {
            // ConcurrentQueue (with while)
            var elements = Enumerable.Range(0, 20).ToList();
            var coll = new ConcurrentQueue<int>(elements);
            coll.Enqueue(999);

            var t1 = Task.Run(() =>
            {
                for (int i = 0; i < 20; ++i)
                {
                    coll.Enqueue(i + 100);
                    Thread.Sleep(100);
                }
            });

            var t2 = Task.Run(() =>
            {
                Thread.Sleep(300);
                while (coll.TryDequeue(out int value))
                {
                    Console.WriteLine(value);
                    Thread.Sleep(150);
                }
            });

            try
            {
                Task.WaitAll(t1, t2);
            }
            catch (AggregateException ex) // No exception
            {
                Console.WriteLine(ex.Flatten().Message);
            }
        }

        private static void Demo5()
        {
            // ConcurrentStack

            var elements = Enumerable.Range(0, 20).ToList();
            var coll = new ConcurrentStack<int>(elements);
            coll.Push(999);

            var t1 = Task.Run(() =>
            {
                for (int i = 0; i < 20; ++i)
                {
                    coll.Push(i + 100);
                    Thread.Sleep(100);
                }
            });

            var t2 = Task.Run(() =>
            {
                Thread.Sleep(300);
                while (coll.TryPop(out int value))
                {
                    Console.WriteLine(value);
                    Thread.Sleep(150);
                }
            });

            try
            {
                Task.WaitAll(t1, t2);
            }
            catch (AggregateException ex) // No exception
            {
                Console.WriteLine(ex.Flatten().Message);
            }
        }

        private static void Demo6()
        {
            // ConcurrentBag
            var bag = new ConcurrentBag<int>();

            var t1 = Task.Run(() =>
            {
                for (int i = 1; i < 10; ++i)
                {
                    bag.Add(i);
                    Thread.Sleep(200);
                }
            });

            var t2 = Task.Run(() =>
            {
                int i = 0;
                while (i <= 4)
                {
                    foreach (var item in bag)
                    {
                        Console.WriteLine($"[{i}]  - {item}");
                        Thread.Sleep(200);
                    }
                    i++;
                    Thread.Sleep(200);
                    Console.WriteLine("---------------------------");
                }
            });

            Task.WaitAll(t1, t2);
        }

        private static void Demo7()
        {
            // ConcurrentBag & AutoResetEvent
            var bag = new ConcurrentBag<int>();
            var autoEvent1 = new AutoResetEvent(false);

            var t1 = Task.Run(() =>
            {
                for (int i = 1; i <= 4; ++i)
                {
                    bag.Add(i);
                    Console.WriteLine($"Add {i}");
                }

                //wait for second thread to add its items
                autoEvent1.WaitOne();

                while (bag.IsEmpty == false)
                {
                    int item;
                    if (bag.TryTake(out item))
                    {
                        Console.WriteLine(item);
                    }
                }
            });

            var t2 = Task.Run(() =>
            {
                for (int i = 5; i <= 7; ++i)
                {
                    bag.Add(i);
                    Console.WriteLine($"Add {i}");
                }
                Thread.Sleep(5000);
                autoEvent1.Set();
            });

            t1.Wait();
            t2.Wait();
        }

        private static void Demo8()
        {
            // BlockingCollection
            var bCollection = new BlockingCollection<int>(boundedCapacity: 10);
            var producerThread = Task.Run(() =>
            {
                for (int i = 0; i < 10; ++i)
                {
                    Thread.Sleep(1000);
                    bCollection.Add(i);
                }

                bCollection.CompleteAdding();
            });

            foreach (int item in bCollection.GetConsumingEnumerable())
            {
                Console.WriteLine(item);
            }
        }

        // ConcurrentDictionary

        // ManualResetEvent
    }
}