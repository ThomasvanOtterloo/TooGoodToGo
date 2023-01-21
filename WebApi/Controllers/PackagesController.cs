using Core.Domain;
using Core.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.Models;
using AutoMapper;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.AspNetCore.Http;

namespace WebApi.Controllers
{
    
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class PackagesController : ControllerBase
    {

        private readonly ILogger<PackagesController> _logger;
        private readonly IPackageRepository _packageRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProductRepository _productRepository;

        public PackagesController(ILogger<PackagesController> logger, IPackageRepository packageRepository, IStudentRepository studentRepository, IEmployeeRepository employeeRepository, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor, IProductRepository productRepository)
        {
            _logger = logger;
            _packageRepository = packageRepository;
            _studentRepository = studentRepository;
            _employeeRepository = employeeRepository;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _productRepository = productRepository;
        }



        [HttpGet]
        public async Task<ActionResult<List<PackageDTO>>> GetAllPackages()
        {
            var packages = _packageRepository.GetAllPackages().ToList();


            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            var mapper = config.CreateMapper();
            var packageDTOs = mapper.Map<List<PackageDTO>>(packages);
            return Ok(packageDTOs);
        }




        [HttpGet("{id}")]
        public ActionResult<Package> GetPackageById(int id)
        {
            var package = _packageRepository.GetPackageById(id);
            if (package == null) return NotFound();
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutoMapperProfile>();
            });
            var mapper = config.CreateMapper();
         
          
            var packageDTO = new PackageDTO()
            {
                Id = package.Id,
                StudentId = package.StudentId,
                EmployeeId = package.EmployeeId,
                Name = package.Name,
                Description = package.Description,
                PickUp = package.PickUp,
                Price = package.Price,
                Meal = package.Meal,
                AvailableUntil = package.AvailableUntil,
                Products = mapper.Map<List<ProductDTO>>(package.Products)
            };
            return Ok(packageDTO);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Package>> CreatePackageAsync(Package package)
        {
            try
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                Employee? employee = null;
                try
                {
                    employee = _employeeRepository.GetEmployeeByEmail(user.Email);
                }
                catch
                {
                    return StatusCode(400, new { error = "An error occurred", message = "Admin role not found!", statusCode = 400 });
                }

                package.AvailableUntil = DateTime.Now.AddDays(3);
                package.EmployeeId = employee.Id;
                var products = new List<Product>();
                var getAllProducts = _productRepository.GetAllProducts();

                package.Products.ForEach(id => products.Add(getAllProducts.FirstOrDefault(p => p.Id == id.Id)));
                package.Products = products;

                Console.WriteLine("asdasd" + package.Products);
                await _packageRepository.CreatePackage(package);
                return StatusCode(200, new { message = "Package successfully updated", statusCode = 200 });
            }
            catch (Exception e)
            {
                return StatusCode((400), e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Package>> UpdatePackageAsync(int id, Package package)
        {
            try
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                Employee? employee = null;
                try
                {
                    employee = _employeeRepository.GetEmployeeByEmail(user.Email);
                }
                catch
                {
                    return StatusCode(400, new { error = "An error occurred", message = "Admin role not found!", statusCode = 400 });
                }
                var newPackage = _packageRepository.GetPackageById(id);
                if (newPackage == null) return NotFound();
                newPackage.Name = package.Name;
                newPackage.Description = package.Description;
                newPackage.PickUp = package.PickUp;
                newPackage.Price = package.Price;
                newPackage.Meal = package.Meal;
                var products = new List<Product>();
                var getAllProducts = _productRepository.GetAllProducts();

                package.Products.ForEach(id => products.Add(getAllProducts.FirstOrDefault(p => p.Id == id.Id)));
                newPackage.Products = products;

                await _packageRepository.UpdatePackage(newPackage);

                return StatusCode(200, new { message = "Package successfully updated", statusCode = 200 });
            }
            catch (Exception e)
            {
                return StatusCode((400), e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Package>> DeletePackageAsync(int id)
        {
            try
            {

                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                Employee? employee = null;
                try
                {
                    employee = _employeeRepository.GetEmployeeByEmail(user.Email);
                }
                catch
                {
                    return StatusCode(400, new { error = "An error occurred", message = "Admin role not found!", statusCode = 400 });
                }
                await _packageRepository.DeletePackage(id);
                return Ok("Package deleted!");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode((400), "You are not a Admin, you can't delete a package! If you are, Error: " + e.InnerException);
            }
        }

        [HttpGet("reserved")]
        [Authorize]
        public async Task<ActionResult<List<Package>>> GetAllReservedPackagesAsync()
        {
            try
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                Student? student = null;
                try
                {
                     student = _studentRepository.GetStudentByEmail(user.Email);
                }
                catch
                {
                    return StatusCode(400, new { error = "An error occurred", message = "Student role not found!", statusCode = 400 });
                }

                var packages = _packageRepository.GetAllReservedPackagesByStudent(student).ToList();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<AutoMapperProfile>();
                });
                var mapper = config.CreateMapper();
                var packageDTOs = mapper.Map<List<PackageDTO>>(packages);
                return Ok(packageDTOs);
            }
            catch (Exception e)
            {

                return StatusCode(400, new { error = "An error occurred", message = e.Message, statusCode = 400 });

            }
        }

        [HttpGet("available")]
        [Authorize]
        public ActionResult<List<Package>> GetAllAvailablePackages()
        {
            var packages = _packageRepository.GetAllAvailablePackages().ToList();


            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            var mapper = config.CreateMapper();
            var packageDTOs = mapper.Map<List<PackageDTO>>(packages);
            return Ok(packageDTOs);
        }


        [HttpGet("filter")]
        [Authorize]
        public ActionResult<List<Package>> GetPackagesByFilter(City? city, Meal? meal, String availablity, int? canteen)
        {
            try
            {
                var packages = _packageRepository.GetPackagesByFilter(city, meal, availablity, canteen).ToList();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<AutoMapperProfile>();
                });
                var mapper = config.CreateMapper();
                var packageDTOs = mapper.Map<List<PackageDTO>>(packages);
                return Ok(packageDTOs);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, $"An error occurred:" + e.Message);
            }
        }



        [HttpPut("reserve/{id}")]
        [Authorize]
        public async Task<ActionResult<Package>> ReservePackageAsync(int id)
        {
            try
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                Student? student = null;
                try
                {
                    student = _studentRepository.GetStudentByEmail(user.Email);
                }
                catch
                {
                    return StatusCode(400, new { error = "An error occurred", message = "Student role not found!", statusCode = 400 });
                }
                var package = _packageRepository.GetPackageById(id);
                if (package == null) return NotFound("Package not found");

                await _packageRepository.ReservePackage(package, student);
                return StatusCode(200, new {message = "You Reserved package: " + package.Id, statusCode = 200 });
            }
            catch (Exception e)
            {
                return StatusCode(400, new { error = "An error occurred", message = e.Message, statusCode = 400 });
            }
        }
    }
}