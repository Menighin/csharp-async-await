using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"[T{Thread.CurrentThread.ManagedThreadId}] Woke up");
            var toastTask = StartToastAsync();
            Console.WriteLine($"[T{Thread.CurrentThread.ManagedThreadId}] Watching some tv...");
            await toastTask;
            Console.WriteLine($"[T{Thread.CurrentThread.ManagedThreadId}] Get the toast!");
        }

        static async Task StartToastAsync()
        {
            Console.WriteLine($"[T{Thread.CurrentThread.ManagedThreadId}] Started the toaster...");
            await Task.Delay(2000);
            Console.WriteLine($"[T{Thread.CurrentThread.ManagedThreadId}] Toast is ready!");
        }
    }
}
