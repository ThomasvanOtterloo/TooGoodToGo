using Core.Domain;
using Core.Domain.Services;

namespace Infrastructure
{
    public class EmployeeEFRepository : IEmployeeRepository
    {


        readonly PackageDbContext _context;

        public EmployeeEFRepository(PackageDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.Employee.First(e => e.Id == id);
        }

        public Employee GetEmployeeByEmail(string email)
        {
            return _context.Employee.First(e => e.Email == email);
        }


        public Task SaveChanges()
        {
            _context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
