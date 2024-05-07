using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PropertyRentalManagement.Models;

namespace PropertyRentalManagement.Controllers
{

    public class ApartmentsController : Controller
    {
        private readonly PropertyRentalManagementDbContext _context;

        public ApartmentsController(PropertyRentalManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            IQueryable<Apartment> apartments = _context.Apartments.Include(a => a.Building).Include(a => a.Status);

            if (!string.IsNullOrEmpty(searchString))
            {
                apartments = apartments.Where(a => a.ApartmentNumber.ToString().Contains(searchString) ||
                                   (a.Status != null && a.Status.Description.Contains(searchString)) ||
                                   a.Description.Contains(searchString));
            }

            return View(await apartments.ToListAsync());
        }


        // GET: Apartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartments
                .Include(a => a.Building)
                .Include(a => a.Status)
                .FirstOrDefaultAsync(m => m.ApartmentId == id);
            if (apartment == null)
            {
                return NotFound();
            }

            return View(apartment);
        }

        // GET: Apartments/Create
        public IActionResult Create()
        {
            ViewData["BuildingId"] = new SelectList(_context.Buildings, "BuildingId", "BuildingName");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Description");
            return View();
        }

        // POST: Apartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApartmentId,BuildingId,ApartmentNumber,StatusId,Description")] Apartment apartment)
        {
            if (ModelState.IsValid)
            {
                int maxId = _context.Apartments.Max(u => (int?)u.ApartmentId) ?? 0;
                apartment.ApartmentId = maxId + 1;
                _context.Add(apartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuildingId"] = new SelectList(_context.Buildings, "BuildingId", "BuildingName", apartment.BuildingId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Description", apartment.StatusId);
            return View(apartment);
        }

        // GET: Apartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment == null)
            {
                return NotFound();
            }
            ViewData["BuildingId"] = new SelectList(_context.Buildings, "BuildingId", "BuildingName", apartment.BuildingId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Description", apartment.StatusId);
            return View(apartment);
        }

        // POST: Apartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApartmentId,BuildingId,ApartmentNumber,StatusId,Description")] Apartment apartment)
        {
            if (id != apartment.ApartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApartmentExists(apartment.ApartmentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuildingId"] = new SelectList(_context.Buildings, "BuildingId", "BuildingName", apartment.BuildingId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Description", apartment.StatusId);
            return View(apartment);
        }

        // GET: Apartments/Delete/5
        [Authorize(Roles = "1,2")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartments
                .Include(a => a.Building)
                .Include(a => a.Status)
                .FirstOrDefaultAsync(m => m.ApartmentId == id);
            if (apartment == null)
            {
                return NotFound();
            }

            return View(apartment);
        }

        // POST: Apartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment != null)
            {
                _context.Apartments.Remove(apartment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApartmentExists(int id)
        {
            return _context.Apartments.Any(e => e.ApartmentId == id);
        }
    }
}
