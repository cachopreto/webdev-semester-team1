using System.ComponentModel.DataAnnotations;
using StarterKit.Models;

public class UserValidator
{
    public static bool TryValidateUser(User user, out string validationErrors)
    {
        validationErrors = string.Empty;

        if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
        {
            validationErrors = "First name and last name are required.";
            return false;
        }

        if (!new EmailAddressAttribute().IsValid(user.Email))
        {
            validationErrors = "Invalid email format.";
            return false;
        }

        if (string.IsNullOrEmpty(user.Password) || user.Password.Length < 6)
        {
            validationErrors = "Password must be at least 6 characters long.";
            return false;
        }

        return true;
    }
}
