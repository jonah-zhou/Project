using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PropertyRentalManagement.Models;
using System.Threading.Tasks;
using System.Collections.Generic;



namespace PropertyRentalManagement.Controllers
{

    [Authorize(Roles = "1")]
    public class UsersController : Controller
    {
        private readonly PropertyRentalManagementDbContext _context;

        public UsersController(PropertyRentalManagementDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> LoginAsync(User user)
        {

            var loginUser = _context.Users.SingleOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);


            if (loginUser != null && loginUser.UserType != null)
            {
                if (loginUser.StatusId == 2)
                {
                    ModelState.AddModelError("", "User account is inactive. Please contact the administrator.");
                    return View();
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginUser.UserName),
                    new Claim(ClaimTypes.Role, loginUser.UserType.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    // Additional properties if needed
                };

                // Sign in the user
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);


                switch (loginUser.UserType)
                {
                    case 1://Admin
                        return RedirectToAction("Index", "Users");
                    case 2://Manager
                        return RedirectToAction("Index", "Apartments");
                    case 3://Tenant
                        return RedirectToAction("Index", "Appointments");

                    default:
                        ModelState.AddModelError("", "Invalid UserType");
                        return View();
                }
            }

            ModelState.AddModelError("", "Invalid Username or password");
            return View();
        }
        [AllowAnonymous]
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Signup(User user)
        {
            if (ModelState.IsValid)
            {
                int nextUserId = _context.Users.Max(u => u.UserId) + 1;
                user.UserId = nextUserId;
                user.StatusId = 1;
                user.UserType = 3;
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult Logout()
        {
            return RedirectToAction("Login");
        }

        // GET: Users
        public async Task<IActionResult> Index(string searchString)
        {
            IQueryable<User> users = _context.Users.Include(u => u.Status).Include(u => u.UserTypeNavigation);

            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => u.UserName.Contains(searchString) || u.UserTypeNavigation.UserTypeDescription.Contains(searchString));
            }

            return View(await users.ToListAsync());
        }



        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Status)
                .Include(u => u.UserTypeNavigation)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Description");
            ViewData["UserType"] = new SelectList(_context.UserTypes, "UserTypeId", "UserTypeDescription");

            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserName,Password,UserType,StatusId")] User user)
        {
            if (ModelState.IsValid)
            {
                int maxUserId = _context.Users.Max(u => (int?)u.UserId) ?? 0;
                user.UserId = maxUserId + 1;
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Description", user.StatusId);
            ViewData["UserType"] = new SelectList(_context.UserTypes, "UserTypeId", "UserTypeDescription", user.UserType);
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Description", user.StatusId);
            ViewData["UserType"] = new SelectList(_context.UserTypes, "UserTypeId", "UserTypeDescription", user.UserType);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserName,Password,UserType,StatusId")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
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
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Description", user.StatusId);
            ViewData["UserType"] = new SelectList(_context.UserTypes, "UserTypeId", "UserTypeIdDescription", user.UserType);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Status)
                .Include(u => u.UserTypeNavigation)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

    }
}
