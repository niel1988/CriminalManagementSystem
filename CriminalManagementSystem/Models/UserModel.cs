using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;

namespace CriminalManagementSystem.Models
{
    public class LoginModel
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
    public class UserModel : LoginModel
    {
        public int Id { get; set; }

        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Mobile { get; set; }
        public string? Designation { get; set; }
        public bool IsAdmin { get; set; } = false;
        [Required]
        public string? ConfirmPassword { get; set; }
    }
}
