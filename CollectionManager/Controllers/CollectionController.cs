using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollectionManager.Data;
using CollectionManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollectionManager.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ApplicationDbContext _applicationContext;
        public CollectionController(ApplicationDbContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if(id != null)
            {
                Collection collection = await _applicationContext.Collections.FindAsync(id);
                if(collection != null)
                {
                    var items = _applicationContext.Items.Where(item => item.CollectionId == id).Include(i => i.Likes);
                    ViewBag.CollectionData = collection;
                    return View(items);
                }
            }
            return NotFound();
        }

        public IActionResult AddItemToCollection(int? collectionId)
        {
            if(collectionId != null)
            {
                Item item = new Item();
                item.CollectionId = 1;
                return View();
            }
            return NotFound("There is no collection with this id");
        }

        //[HttpPost]
        //public IActionResult AddItem(Item item)
        //{
        //    if(item != null)
        //    {
        //        item.AddingTime = DateTime.Now;
        //        _applicationContext.Items.Add(item);
        //        _applicationContext.SaveChanges();
        //    }
        //}

    }
}
