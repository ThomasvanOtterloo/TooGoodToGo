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

namespace Portal.Controllers
{
    public class PackageController : Controller
    {
        private readonly PackageDbContext _context;
        //private readonly SignInManager<Student> signInManager;

        public PackageController(PackageDbContext context)
        {
            _context = context;
            //this.signInManager = signInManager;
        }

        // GET: Package 
        public async Task<IActionResult> Index()
        {
            return View(await _context.Packages.ToListAsync());
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

            return View(Packages);
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
            return View();
        }

        // POST: Jokes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Discription,IsAdult")] Package package)
        {
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

        //// GET: Jokes/Delete/5
        //[Authorize]
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Joke == null)
        //    {
        //        return NotFound();
        //    }

        //    var joke = await _context.Joke
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (joke == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(joke);
        //}

        //// POST: Jokes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //[Authorize]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Joke == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Joke'  is null.");
        //    }
        //    var joke = await _context.Joke.FindAsync(id);
        //    if (joke != null)
        //    {
        //        _context.Joke.Remove(joke);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool PackageExists(int id)
        {
            return _context.Packages.Any(e => e.Id == id);
        }
    }
}
