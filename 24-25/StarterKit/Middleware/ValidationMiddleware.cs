using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using StarterKit.Models;
public class ValidationMiddleware
{
    private readonly RequestDelegate _next;

    public ValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Assuming you're binding the request body to a User object
        var user = context.Items["User"] as User;

        if (user != null)
        {
            if (!UserValidator.TryValidateUser(user, out var validationErrors))
            {
                context.Response.StatusCode = 412; // Precondition Failed
                await context.Response.WriteAsync($"Validation failed: {validationErrors}");
                return;
            }
        }

        await _next(context);
    }
}
