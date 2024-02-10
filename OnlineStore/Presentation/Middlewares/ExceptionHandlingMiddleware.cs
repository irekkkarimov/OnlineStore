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
            var newJsonResult = new { statusCode = e.StatusCode, message = e.Message };
            var messageJson = JsonSerializer.Serialize(newJsonResult);
            Console.WriteLine(messageJson);
            context.Response.StatusCode = e.StatusCode;
            await context.Response.WriteAsync(messageJson);
        }
        catch (Exception e)
        {
            var newJsonResult = new { statusCode = 500, message = e.Message };
            var messageJson = JsonSerializer.Serialize(newJsonResult);
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync(messageJson);
        }
    }
}