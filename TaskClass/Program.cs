using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo8().Wait();

            // task.run
            // task.wait
            // new thread
            // Task<T>
            // Task.WaitAll
           
        }

        static void Demo1()
        {
            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Statred");
            Task task1 = new Task(PrintCounter);
            task1.Start();
            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
            Console.ReadKey();
        }

        static void PrintCounter()
        {
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
            for (int count = 1; count <= 5; count++)
            {
                Console.WriteLine($"count value: {count}");
            }
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
        }

        static void Demo2()
        {
            Console.WriteLine($"Main Thread Started");
            Task<double> task1 = Task.Run(() =>
            {
                return CalculateSum(10);
            });

            Console.WriteLine($"Sum is: {task1.Result}");
            Console.WriteLine($"Main Thread Completed");
            Console.ReadKey();
        }

        static double CalculateSum(int num)
        {
            double sum = 0;
            for (int count = 1; count <= num; count++)
            {
                sum += count;
            }
            return sum;
        }

        static void Demo3()
        {
            Task<string> task1 = Task.Run(() =>
            {
                return 12;
            }).ContinueWith((antecedent) =>
            {
                return $"The Square of {antecedent.Result} is: {antecedent.Result * antecedent.Result}";
            });
            Console.WriteLine(task1.Result);

            Console.ReadKey();
        }

        static void Demo4()
        {
            Task<int> task = Task.Run(() =>
            {
                return 10;
            });
            task.ContinueWith((i) =>
            {
                Console.WriteLine("TasK Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);
            task.ContinueWith((i) =>
            {
                Console.WriteLine("Task Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);

            var completedTask = task.ContinueWith((i) =>
            {
                Console.WriteLine("Task Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            
            completedTask.Wait();
            Console.ReadKey();
        }

        static void Demo5()
        {
            Console.WriteLine("C# For Loop");
            int number = 10;
            for (int count = 0; count < number; count++)
            {
                //Thread.CurrentThread.ManagedThreadId returns an integer that 
                //represents a unique identifier for the current managed thread.
                Console.WriteLine($"value of count = {count}, thread = {Thread.CurrentThread.ManagedThreadId}");
                //Sleep the loop for 10 miliseconds
                Thread.Sleep(10);
            }
            Console.WriteLine();
            Console.WriteLine("Parallel For Loop");
            Parallel.For(0, number, count =>
            {
                Console.WriteLine($"value of count = {count}, thread = {Thread.CurrentThread.ManagedThreadId}");
                //Sleep the loop for 10 miliseconds
                Thread.Sleep(10);
            });
            Console.ReadLine();
        }

        static void Demo6_1()
        {
            DateTime StartDateTime = DateTime.Now;
            Console.WriteLine(@"For Loop Execution start at : {0}", StartDateTime);
            for (int i = 0; i < 10; i++)
            {
                long total = DoSomeIndependentTask();
                Console.WriteLine("{0} - {1}", i, total);
            }
            DateTime EndDateTime = DateTime.Now;
            Console.WriteLine(@"For Loop Execution end at : {0}", EndDateTime);
            TimeSpan span = EndDateTime - StartDateTime;
            int ms = (int)span.TotalMilliseconds;
            Console.WriteLine(@"Time Taken to Execute the For Loop in miliseconds {0}", ms);
            Console.WriteLine("Press any key to exist");
            Console.ReadLine();
        }

        static void Demo6_2()
        {
            DateTime StartDateTime = DateTime.Now;
            Console.WriteLine(@"Parallel For Loop Execution start at : {0}", StartDateTime);
            Parallel.For(0, 10, i => {
                long total = DoSomeIndependentTask();
                Console.WriteLine("{0} - {1}", i, total);
            });
            DateTime EndDateTime = DateTime.Now;
            Console.WriteLine(@"Parallel For Loop Execution end at : {0}", EndDateTime);
            TimeSpan span = EndDateTime - StartDateTime;
            int ms = (int)span.TotalMilliseconds;
            Console.WriteLine(@"Time Taken to Execute the Loop in miliseconds {0}", ms);
            Console.WriteLine("Press any key to exist");
            Console.ReadLine();
        }

        static long DoSomeIndependentTask()
        {
            //Do Some Time Consuming Task here
            //Most Probably some calculation or DB related activity
            long total = 0;
            for (int i = 1; i < 100000000; i++)
            {
                total += i;
            }
            return total;
        }

        static void Demo7()
        {
            Parallel.Invoke(
                   () => DoSomeTask(1),
                   () => DoSomeTask(2),
                   () => DoSomeTask(3),
                   () => DoSomeTask(4),
                   () => DoSomeTask(5),
                   () => DoSomeTask(6),
                   () => DoSomeTask(7)
               );
            Console.ReadKey();
        }

        static void DoSomeTask(int number)
        {
            Console.WriteLine($"DoSomeTask {number} started by Thread {Thread.CurrentThread.ManagedThreadId}");
            //Sleep for 5000 milliseconds
            Thread.Sleep(5000);
            Console.WriteLine($"DoSomeTask {number} completed by Thread {Thread.CurrentThread.ManagedThreadId}");
        }

        static async Task Demo8()
        {
            var tokenSource2 = new CancellationTokenSource();
            CancellationToken ct = tokenSource2.Token;

            var task = Task.Run(() =>
            {
                // Were we already canceled?
                ct.ThrowIfCancellationRequested();

                bool moreToDo = true;
                while (moreToDo)
                {
                    Console.WriteLine("Do something...");
                    Thread.Sleep(500);
                    // Poll on this property if you have to do
                    // other cleanup before throwing.
                    if (ct.IsCancellationRequested)
                    {
                        // Clean up here, then...
                        ct.ThrowIfCancellationRequested();

                        break;
                    }
                }
            }, tokenSource2.Token); // Pass same token to Task.Run.


            Thread.Sleep(5000);

            

            // Just continue on this thread, or await with try-catch:
            try
            {
                tokenSource2.Cancel();
                await task;

                Console.WriteLine("Finish");
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine($"{nameof(OperationCanceledException)} thrown with message: {e.Message}");
            }
            finally
            {
                tokenSource2.Dispose();
            }

            Console.ReadLine();
        }
    }
}
