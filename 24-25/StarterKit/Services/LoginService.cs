using Microsoft.EntityFrameworkCore;
using StarterKit.Models;
using StarterKit.Utils;
namespace StarterKit.Services;

public class LoginService : ILoginService
{
    private readonly DatabaseContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LoginService(DatabaseContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<User?> LogIn(string email, string password)
    {
        var hashedPass = HashPass(password);
        return await _dbContext.Users.FirstOrDefaultAsync(a => a.Email == email && a.Password == hashedPass);
    }

    public async Task<User> RegisterAcc(string name, string email, string password)
    {
        var hashedPass = HashPass(password);
        var newAcc = new User { FirstName = name, Email = email, Password = hashedPass };

        _dbContext.Users.Add(newAcc);
        await _dbContext.SaveChangesAsync();

        return newAcc;
    }

    public bool CheckPassword(string email, string password)
    {
        var account = _dbContext.Users.FirstOrDefault(a => a.Email == email);
        if (account == null)
        {
            return false;
        }
        return BCrypt.Net.BCrypt.Verify(password, account.Password);
    }

    private string HashPass(string pass)
    {
        using (var sha256 = System.Security.Cryptography.SHA256.Create())
        {
            var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));
            return string.Concat(bytes.Select(b => b.ToString("x2")));
        }
    }
    


    public async Task<string> LoginAsync(string username, string password)
    {
        var admin = await _dbContext.Admins.FirstOrDefaultAsync(a => a.UserName == username);
        if (admin == null) return "Admin not found";

        if (admin.Password != EncryptionHelper.EncryptPassword(password)) return $"Incorrect password {admin.Password} : {EncryptionHelper.EncryptPassword(password)}";

        // Register session
        _httpContextAccessor.HttpContext.Session.SetString("AdminUsername", admin.UserName);

        return "Login successful";
    }
    public bool IsLoggedIn(out string username)
    {
        username = _httpContextAccessor.HttpContext.Session.GetString("AdminUsername");
        return username != null;
    }
}
