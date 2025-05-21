using EmployeeAPI.Interfaces;

namespace EmployeeAPI.UseCase
{
    public class GetEmployeeUseCase(IEmployeeRepository repository) : IGetEmployeeUseCase
    {
        public async Task<string> GetEmployee(string name)
        {
            var result = await repository.GetEmployee(name);
            return result;
        }
    }
}
