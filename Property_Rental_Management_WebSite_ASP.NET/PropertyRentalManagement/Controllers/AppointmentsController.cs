using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PropertyRentalManagement.Models;

namespace PropertyRentalManagement.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly PropertyRentalManagementDbContext _context;

        public AppointmentsController(PropertyRentalManagementDbContext context)
        {
            _context = context;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var propertyRentalManagementDbContext = _context.Appointments.Include(a => a.Apartment).Include(a => a.PropertyManager).Include(a => a.Tenant);
            return View(await propertyRentalManagementDbContext.ToListAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Apartment)
                .Include(a => a.PropertyManager)
                .Include(a => a.Tenant)
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create

        public IActionResult Create()
        {
            ViewData["ApartmentId"] = new SelectList(_context.Apartments, "ApartmentId", "ApartmentNumber");
            ViewData["PropertyManagerId"] = new SelectList(_context.Users, "UserId", "UserName");
            ViewData["TenantId"] = new SelectList(_context.Users, "UserId", "UserName");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentId,PropertyManagerId,TenantId,ApartmentId,AppointmentDateTime")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                int maxId = _context.Appointments.Max(u => (int?)u.AppointmentId) ?? 0;
                appointment.AppointmentId = maxId + 1;
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApartmentId"] = new SelectList(_context.Apartments, "ApartmentId", "ApartmentNumber", appointment.ApartmentId);
            ViewData["PropertyManagerId"] = new SelectList(_context.Users, "UserId", "UserName", appointment.PropertyManagerId);
            ViewData["TenantId"] = new SelectList(_context.Users, "UserId", "UserName", appointment.TenantId);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["ApartmentId"] = new SelectList(_context.Apartments, "ApartmentId", "ApartmentNumber", appointment.ApartmentId);
            ViewData["PropertyManagerId"] = new SelectList(_context.Users, "UserId", "UserName", appointment.PropertyManagerId);
            ViewData["TenantId"] = new SelectList(_context.Users, "UserId", "UserName", appointment.TenantId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentId,PropertyManagerId,TenantId,ApartmentId,AppointmentDateTime")] Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.AppointmentId))
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
            ViewData["ApartmentId"] = new SelectList(_context.Apartments, "ApartmentId", "ApartmentNumber", appointment.ApartmentId);
            ViewData["PropertyManagerId"] = new SelectList(_context.Users, "UserId", "UserName", appointment.PropertyManagerId);
            ViewData["TenantId"] = new SelectList(_context.Users, "UserId", "UserName", appointment.TenantId);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Apartment)
                .Include(a => a.PropertyManager)
                .Include(a => a.Tenant)
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.AppointmentId == id);
        }
    }
}
