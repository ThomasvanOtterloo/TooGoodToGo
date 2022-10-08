using Core.Domain;
using Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PackagesController : ControllerBase
    {

        private readonly ILogger<PackagesController> _logger;
        private readonly IPackageRepository _packageRepository;

        public PackagesController(ILogger<PackagesController> logger, IPackageRepository packageRepository)
        {
            _logger = logger;
            _packageRepository = packageRepository ?? throw new ArgumentNullException(nameof(packageRepository));
        }

        [HttpGet]
        public ActionResult<List<Package>> GetAllPackages()
        {
            return Ok(_packageRepository.GetAllPackages().ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Package> GetPackageById(int id)
        {
            return Ok(_packageRepository.GetPackageById(id));
        }
    }
}