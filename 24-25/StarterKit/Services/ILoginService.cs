using StarterKit.Models;
namespace StarterKit.Services;

public interface ILoginService
{
    Task<string> LoginAsync(string username, string password);
    bool IsLoggedIn(out string username);
}
