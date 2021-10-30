
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace first_core_app.Middlewares
{
    public class TodoMiddleware
    {
        readonly RequestDelegate _next;
        public TodoMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {

            if (1 == 1)
            {
                // todo something
                // check auth
            }

            context.Request.Headers.TryGetValue("Authorization", out var token);

            if (token.Count() == 0 || (token.Count() > 0 && token.First() != "Bearer validtokenvalue"))
            {

                context.Response.Clear();
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Unauthorized");
                return;
                //throw new UnauthorizedAccessException();

            }



            //context.Request.Headers.Add("Authorization", "Bearer " + token.First());


            try
            {
                await _next(context);
            }
            finally
            {
                string logText = $"{context.Request?.Method} {context.Request?.Path.Value} => {context.Response?.StatusCode}{Environment.NewLine}";
                Console.WriteLine(logText);
            }
        }
    }

    public static class TodoMiddlewareExtension
    {
        public static IApplicationBuilder UseTodo(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TodoMiddleware>();
        }
    }
}



