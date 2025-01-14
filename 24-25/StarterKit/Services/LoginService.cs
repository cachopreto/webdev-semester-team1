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
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    return "Username and password are required";

                var admin = await _dbContext.Admin.FirstOrDefaultAsync(a => a.UserName == username);
                if (admin == null)
                {
                    throw new Exception($"Admin not found with username: {username}");
                }

                // First try BCrypt verification
                try 
                {
                    if (EncryptionHelper.VerifyPassword(password, admin.Password))
                    {
                        var httpContext = _httpContextAccessor.HttpContext 
                            ?? throw new InvalidOperationException("HttpContext is not available");

                        httpContext.Session.SetString(SESSION_KEY, admin.UserName);
                        return "Login successful";
                    }
                }
                catch (BCrypt.Net.SaltParseException)
                {
                    // If BCrypt verification fails, try direct comparison
                    if (password == admin.Password)
                    {
                        var httpContext = _httpContextAccessor.HttpContext 
                            ?? throw new InvalidOperationException("HttpContext is not available");

                        httpContext.Session.SetString(SESSION_KEY, admin.UserName);
                        
                        // Update password with proper hashing
                        admin.Password = EncryptionHelper.EncryptPassword(password);
                        await _dbContext.SaveChangesAsync();
                        
                        return "Login successful";
                    }
                }

                return "Incorrect password";
            }
            catch (Exception ex)
            {
                throw new Exception($"Login failed: {ex.Message}", ex);
            }
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
