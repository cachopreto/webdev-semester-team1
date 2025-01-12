using StarterKit.Models;
namespace StarterKit.Services;

public interface ILoginService
{
    Task<User?> LogIn(string email, string password);
    Task<User> RegisterAcc(string name, string email, string password);
    bool CheckPassword(string email, string password); 
}