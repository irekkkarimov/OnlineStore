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
            Console.WriteLine(e.Message);
            context.Response.StatusCode = e.StatusCode;
            context.Response.ContentType = "text/json";
            await context.Response.WriteAsync(messageJson);
        }
        catch (Exception e)
        {
            var newJsonResult = new { statusCode = 500, message = e.Message };
            var messageJson = JsonSerializer.Serialize(newJsonResult);
            Console.WriteLine(e.Message);
            context.Response.StatusCode = 500;
            context.Response.ContentType = "text/json";
            await context.Response.WriteAsync(messageJson);
        }
    }
}