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

        public Student GetStudentByEmail(string email)
        {
            return _context.Students.First(s => s.Email == email);
        }


        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }


        public Student? AddStudent(Student student)
        {
            DateTime minimumAge = DateTime.Now.AddYears(-16);
            if (student.BirthDate > minimumAge)
                throw new ArgumentException("Student must be at least 16 years old");
            if (student.Email == null)
                throw new ArgumentException("Student must have an email");
            if (student.Name == null)
                throw new ArgumentException("Student must have a name");
          

            _context.Students.Add(student);
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
