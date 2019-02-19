using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MyMiddleware.MyFukin
{
    public class MyFuckinMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public MyFuckinMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<MyFuckinMiddleware>();
        }

        public Task Invoke(HttpContext tc)
        {
            _logger.LogInformation("我是 MyFukin Middleware");
            // Console.WriteLine("我是 MyFukin Middleware");
            return _next(tc);
        }
    }
}