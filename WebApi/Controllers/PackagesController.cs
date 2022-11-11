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
        public ActionResult<List<Package>> Get()
        {
            return Ok(_packageRepository.GetAllAvailablePackages());
        }
        
        [HttpGet("{id}")]
        public ActionResult<Package> GetPackageById(int id)
        {
            return Ok(_packageRepository.GetPackageById(id));
        }

        [HttpPost]
        public ActionResult<Package> CreatePackage(Package package)
        {
            _packageRepository.CreatePackage(package);
            return Ok(package);
        }

        [HttpPut]
        public ActionResult<Package> UpdatePackage(Package package)
        {
            _packageRepository.UpdatePackage(package);
            return Ok(package);
        }

        [HttpDelete("{id}")]
        public ActionResult<Package> DeletePackage(int id)
        {
            _packageRepository.DeletePackage(id);
            return Ok();
        }
        
        
        
    }
}