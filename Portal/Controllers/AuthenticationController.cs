using Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Portal.Controllers
{
    public class AuthenticationController : Controller
    {

        private readonly ILogger<AuthenticationController> _logger;
        private readonly IStudentRepository _studentRepository;

        public AuthenticationController(ILogger<AuthenticationController> logger, IStudentRepository studentRepository)
        {
            _logger = logger;
            _studentRepository = studentRepository;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginStudent()
        {

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

    }
}
