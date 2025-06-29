using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        required public string Username { get; set; }
        [NotMapped]
        required public string Password { get; set; } // Plain password for registration
        required public string PasswordHash { get; set; } // For login matching
    }
}
