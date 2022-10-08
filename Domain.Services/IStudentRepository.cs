using Core.Domain;

namespace Domain.Services
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentById(int id);

        Student? AddStudent(Student student);
    }
}