using Core.Domain;
using Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public ActionResult<List<Student>> GetAllStudents()
        {
            return Ok(_studentRepository.GetAllStudents().ToList());
        }

        [HttpPost]
        public ActionResult<Student> CreateStudent(Student student)
        {
            _studentRepository.CreateStudent(student);
            return Ok(student);
        }

        [HttpPut]
        public ActionResult<Student> UpdateStudent(Student student)
        {
            _studentRepository.UpdateStudent(student);
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            _studentRepository.DeleteStudent(id);
            return Ok();
        }
    }
    
    
}
