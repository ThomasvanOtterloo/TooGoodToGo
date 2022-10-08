using Core.Domain;
using Domain.Services;

namespace Infrastructure
{
    public class StudentEFRepository : IStudentRepository
    {
        readonly PackageDbContext _context;

        public StudentEFRepository(PackageDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.First(s => s.Id == id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Students.ToList();
        }


        public Student? AddStudent(Student student)
        {
            DateOnly reference = new(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            if (student.BirthDate > reference) return null;
            return student;

        }
    }
}
