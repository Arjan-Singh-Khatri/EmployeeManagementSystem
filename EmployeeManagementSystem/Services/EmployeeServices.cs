using EmployeeManagementSystem.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Services
{
        public class EmployeeService
        {
            private readonly AppDbContext _context;

            public EmployeeService(AppDbContext context)
            {
                _context = context;
            }

            public async Task<List<EmployeeModel>> GetAllEmployees()
            {
                return await _context.Employees
                    .FromSqlRaw("EXEC GetAllEmployees")
                    .ToListAsync();
            }

            public async Task AddEmployee(EmployeeModel emp)
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC AddEmployee @Name, @Position, @Department, @Salary",
                    new SqlParameter("@Name", emp.Name),
                    new SqlParameter("@Position", emp.Position),
                    new SqlParameter("@Department", emp.Department),
                    new SqlParameter("@Salary", emp.Salary)
                );
            }

            public async Task UpdateEmployee(EmployeeModel emp)
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC UpdateEmployee @Id, @Name, @Position, @Department, @Salary",
                    new SqlParameter("@Id", emp.Id),
                    new SqlParameter("@Name", emp.Name),
                    new SqlParameter("@Position", emp.Position),
                    new SqlParameter("@Department", emp.Department),
                    new SqlParameter("@Salary", emp.Salary)
                );
            }

            public async Task DeleteEmployee(int id)
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC DeleteEmployee @Id",
                    new SqlParameter("@Id", id)
                );
            }
        }

}
