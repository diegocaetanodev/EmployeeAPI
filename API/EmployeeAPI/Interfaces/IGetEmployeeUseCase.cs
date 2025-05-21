namespace EmployeeAPI.Interfaces
{
    public interface IGetEmployeeUseCase
    {
        Task<string> GetEmployee(string name);
    }
}
