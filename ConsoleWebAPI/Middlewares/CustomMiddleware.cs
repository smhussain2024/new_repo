
namespace ConsoleWebAPI.Middlewares
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("hello from Custom Middleware \n");
            await next(context);
            await context.Response.WriteAsync("hello from Custom Middleware Response \n");
        }
    }
}
