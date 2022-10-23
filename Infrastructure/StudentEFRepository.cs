using Core.Domain;
using Core.Domain.Services;


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

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }


        public Student? AddStudent(Student student)
        {
            DateOnly reference = new(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            if (student.BirthDate > reference) return null;
            return student;

        }

        public Task CreateStudent(Student student)
        {
            _context.Students.Add(student);
            return Task.CompletedTask;
        }

        public Task UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            return Task.CompletedTask;
        }

        public Task DeleteStudent(int id)
        {
            _context.Students.Remove(_context.Students.First(s => s.Id == id));
            return Task.CompletedTask;
        }
    }
}
