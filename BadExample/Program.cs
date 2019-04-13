using System;
using System.Threading;
using System.Threading.Tasks;

namespace BadExample 
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine($"[T{Thread.CurrentThread.ManagedThreadId}] Started main");
            var task = HeavyWorkAsync();
            Console.WriteLine($"[T{Thread.CurrentThread.ManagedThreadId}] Ended main");
            await task;
        }

        public static async Task HeavyWorkAsync()
        {
            Console.WriteLine($"[T{Thread.CurrentThread.ManagedThreadId}] Starting heavy work");
            Task.Delay(2000);
            Console.WriteLine($"[T{Thread.CurrentThread.ManagedThreadId}] Heavy work finished");
        }
    }
}