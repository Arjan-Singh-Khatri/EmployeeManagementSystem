using EmployeeManagementSystem.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Services
{
    public class UserServices
    {
        private readonly AppDbContext _context;

        public UserServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task RegisterUser(string username, string passwordHash)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC RegisterUser @Username, @PasswordHash",
                    new SqlParameter("@Username", username),
                    new SqlParameter("@PasswordHash", passwordHash)
                );
            }
            catch (Exception ex)
            {
                // Log error here using ILogger (inject via constructor)
                throw new ApplicationException("Error registering user", ex);
            }
        }


        public async Task<UserModel?> GetUserByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username is required", nameof(username));

            try
            {
                return  _context.Users
                .FromSqlRaw("EXEC LoginUser @Username", new SqlParameter("@Username", username))
                .AsEnumerable()
                .FirstOrDefault();

            }
            catch (Exception ex)
            {
                // Log the exception (inject ILogger<UserServices> to your class and use _logger.LogError)
                throw new ApplicationException($"Error fetching user with username '{username}'", ex);
            }
        }

    }
}
