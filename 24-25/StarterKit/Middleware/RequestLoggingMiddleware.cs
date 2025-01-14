using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _logFilePath;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
        _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "requests.log");
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var method = context.Request.Method;
        var url = context.Request.Path;
        var queryParams = context.Request.QueryString.ToString();

        // Store the status code after the request is processed
        context.Response.OnCompleted(async () =>
        {
            var statusCode = context.Response.StatusCode;
            var logMessage = $"{DateTime.UtcNow:O} - {method} {url} - Query Params: {queryParams} - Status: {statusCode}\n";

            try
            {
                await File.AppendAllTextAsync(_logFilePath, logMessage);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to write log: {ex.Message}");
            }
        });

        // Call the next middleware in the pipeline
        await _next(context);
    }
}
