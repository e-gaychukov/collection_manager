using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollectionManager.Data;
using CollectionManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollectionManager.Controllers
{
    [Authorize]
    public class CollectionController : Controller
    {
        private readonly ApplicationDbContext _applicationContext;
        public CollectionController(ApplicationDbContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IActionResult Index(int? id)
        {
            var displayedCollection = LoadCollectionById(id).FirstOrDefault();
            return ViewCollection(displayedCollection);
        }

        public IEnumerable<Collection> LoadCollectionById(int? collectionId)
        {
            var collectionSearchResult = _applicationContext.Collections.Where(c => c.Id == collectionId);     
            return collectionSearchResult.Include(c => c.Items).ThenInclude(i => i.Likes).Include(c => c.Owner);
        }

        public IActionResult ViewCollection(Collection collection)
        {
            return collection != null ? View(collection) : NotFound() as IActionResult;
        }
    }
}
