using System;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using CollectionManager.Data;
using CollectionManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace CollectionManager.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        private readonly ApplicationDbContext _applicationContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _hostEnvironment;

        public UserProfileController(ApplicationDbContext applicationContext,
                                     UserManager<IdentityUser> userManager,
                                     IWebHostEnvironment hostEnvironment)
        {
            _applicationContext = applicationContext;
            _userManager = userManager;
            _hostEnvironment = hostEnvironment;
        }


        public async Task<IActionResult> UserPage(string id)
        {
            if(id != null)
            {
                IdentityUser collectionsOnwer = await _applicationContext.Users.FindAsync(id);
                if(collectionsOnwer != null)
                {
                    ViewData["collectionOwnerData"] = collectionsOnwer;
                    var userCollections = _applicationContext.Collections.Where(c => c.OwnerId == id)
                                                                         .Include(c => c.Topic);                                             
                   return View(userCollections);
                }
            }
            return NotFound("N");
        }


        [HttpPost]
        public async Task<IActionResult> DeleteCollection(int? id)
        {
            if(id != null)
            {
                Collection collection = await _applicationContext.Collections.FindAsync(id);
                if(collection != null)
                {
                    DeleteCollectionImage(collection);
                    _applicationContext.Collections.Remove(collection);
                    await _applicationContext.SaveChangesAsync();
                    return RedirectToAction("UserPage", new {id = collection.OwnerId});
                }
            }
            return NotFound();
        }

        void DeleteCollectionImage(Collection collection)
        {
            if (collection.ImageReference != null) 
            {
                System.IO.File.Delete(GetAbsolutePath(collection.ImageReference));
            }
        }


        public IActionResult AddCollection()
        {
            ViewBag.TopicsList = new SelectList(_applicationContext.Topics, "Id", "Name");
            return View(new Collection());
        }

        [HttpPost]
        public async Task<IActionResult> AddCollection(Collection collection, IFormFile file)
        {
            if (collection != null && ModelState.IsValid)
            {
                if (file != null)
                {
                    collection.ImageReference = Path.Combine("images", GetFileNameWithUniquePostfix(file.FileName));
                    await UploadFileToServer(file, collection.ImageReference);
                }
                collection.OwnerId = (await GetCurrentUser()).Id;
                _applicationContext.Collections.Add(collection);
                await _applicationContext.SaveChangesAsync();
                return RedirectToAction("UserPage", "UserProfile", new {id = (await GetCurrentUser()).Id});
            }
            ViewBag.TopicsList = new SelectList(_applicationContext.Topics, "Id", "Name", collection.TopicId);
            return View(collection);
        }
    
        async Task<IdentityUser> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }

        string GetFileNameWithUniquePostfix(string fileName)
        {
            string namePostfixWithExtension = "-" + Guid.NewGuid().ToString() + Path.GetExtension(fileName);
            return Path.GetFileNameWithoutExtension(fileName) + namePostfixWithExtension;
        }

        async Task UploadFileToServer(IFormFile file, string localPathToFile)
        {
            using (FileStream fileStream = new FileStream(GetAbsolutePath(localPathToFile), FileMode.Create))
                await file.CopyToAsync(fileStream);
        }

        string GetAbsolutePath(string localPath)
        {
            return Path.Combine(_hostEnvironment.WebRootPath, localPath);
        }


        [HttpPost]
        public async Task<IActionResult> EditCollection(int? id)
        {
            if(id != null)
            {
                Collection collection = await _applicationContext.Collections.FindAsync(id);
                ViewBag.TopicsList = new SelectList(_applicationContext.Topics, "Id", "Name", id);
                if (collection != null)
                {
                    return View(collection);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditCollection(Collection collection, IFormFile file)
        {
            if (collection == null)
                return NotFound();

            if(ModelState.IsValid)
            {
                IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);
                if (file != null)
                {
                    if (collection.ImageReference != null)
                    {
                        FileInfo fileInfo = new FileInfo(GetAbsolutePath(collection.ImageReference));
                        fileInfo.Delete();
                    }
                    collection.ImageReference = Path.Combine("images", GetFileNameWithUniquePostfix(file.FileName));
                    await UploadFileToServer(file, collection.ImageReference);
                }
                _applicationContext.Collections.Update(collection);
                await _applicationContext.SaveChangesAsync();
                return RedirectToAction("UserPage", new { id = user.Id });
            }
            return View(collection);
        }
    }
}
