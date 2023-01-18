namespace Core.Domain.Services
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(int id);
        Employee GetEmployeeByEmail(string email);
        Task SaveChanges();

    }
}
