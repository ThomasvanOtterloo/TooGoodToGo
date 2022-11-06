using Core.Domain;

namespace Core.Domain.Services
{
    public interface IStudentRepository
    {
        Student GetStudentByEmail(string email);
        Student GetStudentById(int id);
        IEnumerable<Student> GetAllStudents();
        Task CreateStudent(Student student);
        Task UpdateStudent(Student student);
        Task DeleteStudent(int id);
       

    }
}