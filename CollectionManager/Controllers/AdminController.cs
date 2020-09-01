using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollectionManager.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;

namespace CollectionManager.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _applicationContext;
        private readonly UserManager<IdentityUser> _userManger;
        public AdminController(ApplicationDbContext applicationContext, UserManager<IdentityUser> userManager)
        {
            _applicationContext = applicationContext;
            _userManger = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _applicationContext.Users.ToArrayAsync());
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUserById(string id)
        {
            IdentityUser user = await _userManger.FindByIdAsync(id);
            if(user != null)
            {
                await _userManger.UpdateSecurityStampAsync(user);
                await _userManger.DeleteAsync(user);
            }
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> BlockUserByIdTillDate(string id, DateTimeOffset? lockoutEndDate)
        {
            IdentityUser user = await _userManger.FindByIdAsync(id);
            if (user != null)
            {
                await _userManger.UpdateSecurityStampAsync(user);
                await _userManger.SetLockoutEndDateAsync(user, lockoutEndDate ?? DateTimeOffset.MaxValue);
            }
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> UnBlockUserById(string id)
        {
            IdentityUser user = await _userManger.FindByIdAsync(id);
            if (user != null)
            {
                await _userManger.SetLockoutEndDateAsync(user, null);
            }
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> AssignAdminRoleToUser(string userId)
        {
            IdentityUser user = await _userManger.FindByIdAsync(userId);
            if(user != null)
            {
                await _userManger.AddToRoleAsync(user, "Admin");
            }
            return RedirectToAction("Index", "Admin");
        }
        
        [HttpPost]
        public async Task<IActionResult> DismissUserFromAdminRole(string userId)
        {
            IdentityUser user = await _userManger.FindByIdAsync(userId);
            if (user != null)
            {
                await _userManger.RemoveFromRoleAsync(user, "Admin");
            }
            return RedirectToAction("Index", "Admin");
        }
    }
}
