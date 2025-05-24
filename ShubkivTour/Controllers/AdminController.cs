using Microsoft.AspNetCore.Mvc;
using ShubkivTour.Models;
using ShubkivTour.Models.Entity;
using ShubkivTour.Models.DTO;
using ShubkivTour.Repository.Interfaces;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ShubkivTour.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdminController : Controller
    {
        private readonly UserManager<Client> _userManager;

        public AdminController(UserManager<Client> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Не вдалося видалити користувача.");
                return RedirectToAction("UsersManager");
            }

            return RedirectToAction("UsersManager");
        }

        public async Task<IActionResult> ToggleLock(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            var isLocked = await _userManager.IsLockedOutAsync(user);

            if (isLocked)
            {
                await _userManager.SetLockoutEndDateAsync(user, null);
            }
            else
            {
                await _userManager.SetLockoutEnabledAsync(user, true);
                await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow.AddYears(100));
            }

            return RedirectToAction("UsersManager");
        }

        public async Task<IActionResult> UsersManager(string searchName)
        {
            var users = _userManager.Users.ToList();

            if (!string.IsNullOrEmpty(searchName))
            {
                users = users.Where(u => u.Name != null && u.Name.Contains(searchName, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            var userWithRole = new List<UserWithRole>();

            foreach (var user in users)
            {
                var roles = _userManager.GetRolesAsync(user).Result;
                var role = roles.FirstOrDefault();

                userWithRole.Add(new UserWithRole
                {
                    User = user,
                    Role = role,
                    IsLocked = user.LockoutEnd.HasValue && user.LockoutEnd > DateTimeOffset.UtcNow
                });
            }

            return View(userWithRole);
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }
        public async Task<IActionResult> ChangeRole(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Count == 0)
            {
                await _userManager.AddToRoleAsync(user, "Client");
            }
            else if (roles.Contains("Client"))
            {
                await _userManager.RemoveFromRoleAsync(user, "Client");
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            else if (roles.Contains("Admin"))
            {
                await _userManager.RemoveFromRoleAsync(user, "Admin");
                await _userManager.AddToRoleAsync(user, "Client");
            }

            return RedirectToAction("UsersManager"); 
        }
    }
}
