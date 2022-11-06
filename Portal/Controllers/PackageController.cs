using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Authorization;
using Infrastructure;
using Core.Domain;
using Microsoft.AspNetCore.Identity;
using System.Collections;
using Core.Domain.Services;
using Portal.Models;
using Microsoft.Data.SqlClient.Server;
using NuGet.ContentModel;

namespace Portal.Controllers
{
    public class PackageController : Controller
    {
        private readonly PackageDbContext _context;
        private readonly ICityRepository _cityRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IPackageRepository _packageRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICanteenRepository _canteenRepository;
        private readonly IProductRepository _productRepository;

        public PackageController(PackageDbContext context, ICityRepository cityRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IPackageRepository packageRepository, IStudentRepository studentRepository, ICanteenRepository canteenRepository, IProductRepository productRepository)
        {
            _context = context;
            _cityRepository = cityRepository;
            this.userManager = userManager;
            this.signInManager = signInManager;
            _packageRepository = packageRepository;
            _studentRepository = studentRepository;
            _canteenRepository = canteenRepository;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            var student = _studentRepository.GetAllStudents().FirstOrDefault(s => s.Email == user.Email);

            PackageIndexModel viewModel = new()
            {
                Canteens = _canteenRepository.GetAllCanteens(),

                CanteenList = new List<SelectListItem>()
            };

            foreach (var canteen in viewModel.Canteens)
            {
                viewModel.CanteenList.Add(new SelectListItem(canteen.LocationName, canteen.Id.ToString()));
            }


            if (student != null)
            {
                viewModel.Packages = _packageRepository.GetAllPackagesByStudentCity(student);
            }
            else
            {
                viewModel.Packages = _packageRepository.GetAllAvailablePackages();
            }


            if (TempData["succesMessage"] != null)
            {
                ViewBag.Message = TempData["succesMessage"].ToString();
                return View(viewModel);
            }

            if (TempData["succesfullyDeletedMessage"] != null)
            {
                ViewBag.Message = TempData["succesfullyDeletedMessage"].ToString();
                return View(viewModel);
            }

            if (TempData["succesfullyEditedMessage"] != null)
            {
                ViewBag.Message = TempData["succesfullyEditedMessage"].ToString();
                return View(viewModel);
            }


            return View(viewModel);
        }

        public async Task<IActionResult> IndexFilter(City? city, Meal? meal, string availability, int? CanteenId)
        {
            PackageIndexModel viewModel = new()
            {
                Canteens = _canteenRepository.GetAllCanteens(),
                CanteenList = new List<SelectListItem>()
            };

            foreach (var canteen in viewModel.Canteens)
            {
                viewModel.CanteenList.Add(new SelectListItem(canteen.LocationName, canteen.Id.ToString()));
            }

            viewModel.Packages = _packageRepository.GetPackagesByFilter(city, meal, availability, CanteenId);
            return View("Index", viewModel);
        }




        public async Task<IActionResult> Details(int? id)
        {
            var packageById = _packageRepository.GetPackageById(id);

            DetailsModel detailsModel = new()
            {
                Package = packageById,
                CanteenName = packageById.Employee.Canteen.LocationName,
                Products = packageById.Products
            };

            foreach (var product in packageById.Products)
            {
                if (product.ContainsAlcohol == true)
                {
                    detailsModel.ContainsAlcohol = true;
                }
            }
            return View(detailsModel);
        }


        [Authorize(Policy = "Employee")]
        public IActionResult Create()
        {
            return View(GetProductModel());
        }

        [Authorize]
        [HttpPost]
        [Authorize(Policy = "Employee")]
        public async Task<IActionResult> Create(CreatePackageModel model)
        {
            if (!ModelState.IsValid)
                return View(GetProductModel());

            var package = Map(model);

            var Authuser = await userManager.GetUserAsync(User);
            var DbUser = _context.Employee.Where(s => s.Email == Authuser.Email).FirstOrDefault();

            package.AvailableUntil = DateTime.Now.AddDays(3);
            package.EmployeeId = DbUser.Id;
            try
            {
                await _packageRepository.CreatePackage(package);
                TempData["succesMessage"] = "Package succesfully created";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;

                return View(GetProductModel());
            }
        }

        [Authorize(Policy = "Student")]
        public async Task<IActionResult> ReserveBox(int? id)
        {
            var Package = _packageRepository.GetPackageById(id);

            DetailsModel detailsModel = new()
            {
                Package = Package
            };
            return View(detailsModel);
        }

        [HttpPost, ActionName("ReserveBox")]
        [Authorize(Policy = "Student")]
        public async Task<IActionResult> ReserveBoxComfirm(int id)
        {
            var loggedInUser = await userManager.GetUserAsync(User);
            var loggedInStudent = _studentRepository.GetStudentByEmail(loggedInUser.Email);
            var Package = _packageRepository.GetPackageById(id);

            try
            {
                await _packageRepository.ReservePackage(Package, loggedInStudent);
                TempData["succesMessage"] = "Box successfully reserved. Take a look here to see your reserved boxes.";
                return RedirectToAction(nameof(ReservedBoxes));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [Authorize(Policy = "Student")]
        public async Task<IActionResult> ReservedBoxes()
        {
            var Authuser = await userManager.GetUserAsync(User);
            var LoggedInStudent = _studentRepository.GetStudentByEmail(Authuser.Email);
            var packages = _packageRepository.GetAllReservedPackagesByStudent(LoggedInStudent);

            ReservedPackageModel model = new()
            {
                Packages = packages,
                Student = LoggedInStudent
            };

            if (TempData["succesMessage"] != null)
            {
                ViewBag.Message = TempData["succesMessage"].ToString();
                return View(model);
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            EditPackageViewModel model = await GetDetailInfoModel(id);
            return View(model);
        }

        [HttpPost, ActionName("Edit")]
        [Authorize(Policy = "Employee")]
        public async Task<IActionResult> EditConfirmed(int id, UpdatePackageModel model)
        {
            var package = _packageRepository.GetPackageById(id);

            try
            {
                var UpdatePackage = Map(package, model);
                await _packageRepository.UpdatePackage(UpdatePackage);
                TempData["succesfullyEditedMessage"] = "Box edited successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
                return View(await GetDetailInfoModel(id));
            }
        }


        [Authorize(Policy = "Employee")]
        public async Task<IActionResult> Delete(int? id)
        {
            var Package = _packageRepository.GetPackageById(id);

            DetailsModel detailsModel = new()
            {
                Package = Package
            };

            return View(detailsModel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Employee")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _packageRepository.DeletePackage(id);
                TempData["succesfullyDeletedMessage"] = "Box deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }



        private ProductModel GetProductModel()
        {
            ProductModel productModel = new()
            {
                ProductsList = _productRepository.GetAllProducts().ToList(),
                Canteens = _canteenRepository.GetAllCanteens(),
                Packages = _packageRepository.GetAllPackages()
            };
            return productModel;
        }

        private Package Map(CreatePackageModel model)
        {
            var package = new Package();
            var products = new List<Product>();
            model.Products.ForEach(id => products.Add(_context.Products.First(x => x.Id == id)));
            package.Products = products;
            package.Name = model.Name;
            package.Description = model.Description;
            package.Price = model.Price;
            package.PickUp = model.PickUp;
            package.Meal = model.Meal;
            return package;
        }

        private async Task<EditPackageViewModel> GetDetailInfoModel(int? id)
        {
            var package = _packageRepository.GetPackageById(id);
            var PackageProducts = await _context.Packages.Include(m => m.Products).FirstOrDefaultAsync(m => m.Id == id);
            var Employee = await _context.Employee.Include(m => m.Canteen).FirstOrDefaultAsync(m => m.Id == package.EmployeeId);

            EditPackageViewModel model = new()
            {
                ProductsList = _context.Products.ToList(),
                Canteens = _context.Canteens.ToList(),
                Packages = _context.Packages.ToList(),
                Package = package,
                CanteenName = package.Employee.Canteen.LocationName,
                Products = package.Products,
            };
            foreach (var product in model.Products)
            {
                if (product.ContainsAlcohol == true)
                {
                    model.ContainsAlcohol = true;
                }
            }
            return model;
        }

        private Package Map(Package package, UpdatePackageModel model)
        {
            var products = new List<Product>();
            if (model.Products.Count != 0)
            {
                model.Products.ForEach(id => products.Add(_context.Products.First(x => x.Id == id)));
                package.Products = products;
            }
            if (model.Name != null)
            {
                package.Name = model.Name;
            }
            if (model.Description != null)
            {
                package.Description = model.Description;
            }
            if (model.Price != 0)
            {
                package.Price = model.Price;
            }
            if (package.PickUp <= DateTime.Today)
            {
                package.PickUp = model.PickUp;
            }
            if (model.Meal != null || package.Meal != model.Meal)
            {
                package.Meal = model.Meal;
            }
            return package;
        }

    }
}
