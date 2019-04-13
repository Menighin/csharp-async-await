using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiExample.Controllers
{
    [Route("api")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("TestAsync")]
        public async Task<IActionResult> TestAsync()
        {
            Console.WriteLine($"[T{Thread.CurrentThread.ManagedThreadId}] Started main");
            var task = DoHeavyWorkAsync();
            Console.WriteLine($"[T{Thread.CurrentThread.ManagedThreadId}] Ended main");
            await task;
            return Ok();
        }

        private async Task DoHeavyWorkAsync()
        {
            Console.WriteLine($"[T{Thread.CurrentThread.ManagedThreadId}] Starting heavy work");
            await Task.Delay(2000);
            Console.WriteLine($"[T{Thread.CurrentThread.ManagedThreadId}] Heavy work finished");
        }
    }
}
