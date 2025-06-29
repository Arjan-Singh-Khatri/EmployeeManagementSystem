namespace EmployeeManagementSystem.Models
{
    public class EmployeeModel
    {
        required public int Id { get; set; }
        required public string Name { get; set; }
        required public string Position { get; set; }
        required public string Department { get; set; }
        required public decimal Salary { get; set; }
    }
}
