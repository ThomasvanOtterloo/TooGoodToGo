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

namespace Portal.Controllers
{
    public class PackageController : Controller
    {
        private readonly PackageDbContext _context;
        private readonly ICityRepository cityRepository;
       

        public PackageController(PackageDbContext context, ICityRepository cityRepository)
        {
            _context = context;
            this.cityRepository = cityRepository;
            
        }
       

        // GET: Package 
       
        public async Task<IActionResult> Index()
        {
                return View(await _context.Packages.ToListAsync());
        }

        public async Task<IActionResult> IndexFilter(City selectedItem, Meal meal, string Availability)
        {
            //if (selectedItem == City.All)
            //{
            //    return View("Index", await _context.Packages.ToListAsync());
            //}

            return View("Index", await _context.Packages.ToListAsync());
        }


        
        

        // GET: Jokes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Packages == null)
            {
                return NotFound();
            }

            var Packages = await _context.Packages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Packages == null)
            {
                return NotFound();
            }

            DetailsModel detailsModel = new DetailsModel();
            detailsModel.Package = Packages;
            detailsModel.Products = _context.PackageProducts.Where(p => p.PackageId == id).ToList();
            //detailsModel.CanteenName = _context.Canteens.Where(c => c.Id == Packages.CanteenId).FirstOrDefault().Name;

            return View(detailsModel);
        }

        // GET: Package/Where?ReservedTo=logginInStudentId
        //[Authorize(Policy = "student")]
        public async Task<IActionResult> ReservedBoxes()
        {
            
            //var reserved = await _context.Packages.Where(p => p.ReservedTo.Id == 0);
            return View();

        }



        // GET: Jokes/Create

        public IActionResult Create()
        {
            ProductModel productModel = new ProductModel();
            productModel.ProductsList = _context.Products.ToList();
            productModel.Canteens = _context.Canteens.ToList();
            productModel.Packages = _context.Packages.ToList();


         
            return View(productModel);


           
        }
     
        //[Authorize]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,AvailableUntil,LastUntil,City,CanteenId,PickUp,Price,Meal,Adult,Products")] Package package)
        {

            var price = package.Price;
            var products = package.Products;
            if (ModelState.IsValid)
            {
                _context.Add(package);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(package);
        }

        // GET: Package/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Packages == null)
            {
                return NotFound();
            }

            var package = await _context.Packages.FindAsync(id);
            if (package == null)
            {
                return NotFound();
            }
            return View(package);
        }

        public async Task<IActionResult> ReservedBoxes(int? id)
        {
            if (id == null || _context.Packages == null)
            {
                return NotFound();
            }

            var package = await _context.Packages.Where(a => a.StudentId == id).ToListAsync();
            if (package == null)
            {
                return NotFound();
            }
            return View(package);
        }


        //// POST: Jokes/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,JokeQuestion,JokeAnswer")] Joke joke)
        //{
        //    if (id != joke.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(joke);

        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!JokeExists(joke.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(joke);
        //}


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Packages == null)
            {
                return NotFound();
            }

            var Package = await _context.Packages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Package == null)
            {
                return NotFound();
            }

            DetailsModel detailsModel = new DetailsModel();
            detailsModel.Package = Package;

            return View(detailsModel);
        }

        // POST: Jokes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Packages == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Joke'  is null.");
            }
            var Package = await _context.Packages.FindAsync(id);
            if (Package != null)
            {
                _context.Packages.Remove(Package);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Packages/Delete/5


        private bool PackageExists(int id)
        {
            return _context.Packages.Any(e => e.Id == id);
        }


    }
}
