using Microsoft.EntityFrameworkCore;
using StarterKit.Models;
using StarterKit.Utils;
namespace StarterKit.Services;

public class LoginService : ILoginService
{
    private readonly DatabaseContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private const string SESSION_KEY = "AdminUsername";

    public LoginService(DatabaseContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }

    public async Task<string> LoginAsync(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            return "Username and password are required";

        var admin = await _dbContext.Admins.FirstOrDefaultAsync(a => a.UserName == username);
        if (admin == null) 
            return "Admin not found";

        if (!EncryptionHelper.VerifyPassword(password, admin.Password))
            return "Incorrect password";

        var httpContext = _httpContextAccessor.HttpContext 
            ?? throw new InvalidOperationException("HttpContext is not available");

        // Register session
        httpContext.Session.SetString(SESSION_KEY, admin.UserName);
        return "Login successful";
    }

    public bool IsLoggedIn(out string username)
    {
        username = string.Empty;
        var httpContext = _httpContextAccessor.HttpContext;
        
        if (httpContext == null)
            return false;

        username = httpContext.Session.GetString(SESSION_KEY) ?? string.Empty;
        return !string.IsNullOrEmpty(username);
    }
}
