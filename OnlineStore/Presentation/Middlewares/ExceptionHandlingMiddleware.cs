using System.Text.Json;
using Application.Abstractions.CustomExceptions.Abstractions;

namespace Presentation.Middlewares;

public class ExceptionHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (CustomException e)
        {
            var messageJson = JsonSerializer.Serialize(e.Message);
            Console.WriteLine(messageJson);
            context.Response.StatusCode = e.StatusCode;
            await context.Response.WriteAsync("hui");
        }
        catch (Exception e)
        {
            var messageJson = JsonSerializer.Serialize(e.Message);
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync(messageJson);
        }
    }
}