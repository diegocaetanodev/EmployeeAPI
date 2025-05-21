namespace EmployeeAPI.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<string> GetEmployee(string name);
    }
}
