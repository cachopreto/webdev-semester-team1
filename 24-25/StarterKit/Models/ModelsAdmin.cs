using System.ComponentModel.DataAnnotations;

namespace StarterKit.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public Admin()
        {
            // Default constructor for EF Core
        }

        public Admin(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
        }
    }
}
